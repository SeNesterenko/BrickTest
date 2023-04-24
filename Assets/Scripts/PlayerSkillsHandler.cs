using System;
using System.Linq;
using Events;
using Models;
using SimpleEventBus.Disposables;

public class PlayerSkillsHandler : IDisposable
{
    private readonly CompositeDisposable _subscriptions;
    private readonly PlayerModel _playerModel;
    private readonly SkillModel _baseSkill;

    public PlayerSkillsHandler(PlayerModel playerModel)
    {
        _playerModel = playerModel;

        _baseSkill = _playerModel.Skills.First();
        _baseSkill.IsStudied = true;
        
        _subscriptions = new CompositeDisposable
        {
            EventStreams.Game.Subscribe<SkillSelectedEvent>(CheckPossibilityActiveSkill),
            EventStreams.Game.Subscribe<SkillForgetEvent>(ForgetSkill),
            EventStreams.Game.Subscribe<SkillStudyEvent>(StudySkill),
            EventStreams.Game.Subscribe<ForgetAllSkillsEvent>(ForgetAllSkills)
        };
    }

    private void ForgetAllSkills(ForgetAllSkillsEvent eventData)
    {
        foreach (var skill in _playerModel.Skills)
        {
            _playerModel.SkillPoints += skill.Cost;
            skill.IsStudied = false;
        }

        _playerModel.Skills.Clear();
        _playerModel.Skills.Add(_baseSkill);
        _baseSkill.IsStudied = true;
    }

    private void StudySkill(SkillStudyEvent eventData)
    {
        var studyingSkill = eventData.SkillModel;

        if (_playerModel.SkillPoints >= studyingSkill.Cost)
        {
            studyingSkill.IsSelected = false;
            studyingSkill.IsStudied = true;
            _playerModel.SkillPoints -= studyingSkill.Cost;
            _playerModel.Skills.Add(eventData.SkillModel);
        }
        
        EventStreams.Game.Publish(new SelectedSkillCanBeActiveEvent(false, false, studyingSkill));
    }
    
    private void ForgetSkill(SkillForgetEvent eventData)
    {
        var forgettableSkill = eventData.SkillModel;

        _playerModel.Skills.Remove(forgettableSkill);
        _playerModel.SkillPoints += forgettableSkill.Cost;
        forgettableSkill.IsStudied = false;
        forgettableSkill.IsSelected = false;
        
        EventStreams.Game.Publish(new SelectedSkillCanBeActiveEvent(false, false, forgettableSkill));
    }

    private void CheckPossibilityActiveSkill(SkillSelectedEvent eventData)
    {
        var currentSkill = eventData.SkillModel;

        var canStudySkill = CheckStudySkill(currentSkill);
        var canForgetSkill = CheckForgetSkill(currentSkill);
        
        EventStreams.Game.Publish(new SelectedSkillCanBeActiveEvent(canStudySkill, canForgetSkill, currentSkill));
    }

    private bool CheckForgetSkill(SkillModel currentSkill)
    {
        return _playerModel.Skills
            .Contains(currentSkill) && currentSkill.NextSkills
            .All(nextSkill => !_playerModel.Skills
            .Contains(nextSkill));
    }

    private bool CheckStudySkill(SkillModel currentSkill)
    {
        return !_playerModel.Skills
            .Contains(currentSkill) && currentSkill.PreviousSkills
            .Any(previousSkill => _playerModel.Skills
            .Contains(previousSkill));
    }

    public void Dispose()
    {
        _subscriptions?.Dispose();
    }
}