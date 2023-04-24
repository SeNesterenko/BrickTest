using System;
using Events;
using Models;
using SimpleEventBus.Disposables;
using UI.Views;
using UnityEngine;

namespace UI.ViewControllers
{
    [RequireComponent(typeof(SkillInputView))]
    public class SkillInputViewController : MonoBehaviour, IDisposable
    {
        [SerializeField] private SkillInputView _skillInputView;

        private CompositeDisposable _subscriptions;
        private SkillModel _skillModel;

        private void Awake()
        {
            _skillInputView.Initialize(StudySkill, ForgetSkill);
            
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<SelectedSkillCanBeActiveEvent>(ActivateButtonSelectedSkillButton)
            };
            
            _skillInputView.ResetButtons(false, false);
        }

        private void StudySkill()
        {
            EventStreams.Game.Publish(new SkillStudyEvent(_skillModel));
        }

        private void ForgetSkill()
        {
            EventStreams.Game.Publish(new SkillForgetEvent(_skillModel));
        }

        private void ActivateButtonSelectedSkillButton(SelectedSkillCanBeActiveEvent eventData)
        {
            _skillInputView.ResetButtons(false, false);
            
            if (_skillModel != null)
            {
                _skillModel.IsSelected = false;
            }
            
            _skillModel = eventData.SkillModel;
            
            CheckPossibilityStudySkill(eventData.CanStudySkill);
            CheckPossibilityForgetSkill(eventData.CanForgetSkill);
        }

        private void CheckPossibilityStudySkill(bool canStudySkill)
        {
            if (canStudySkill)
            {
                _skillInputView.DisplayPossibilityStudySkill(_skillModel.Cost.ToString());
            }
        }
        
        private void CheckPossibilityForgetSkill(bool canForgetSkill)
        {
            if (canForgetSkill)
            {
                _skillInputView.DisplayPossibilityForgetSkill();
            }
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}