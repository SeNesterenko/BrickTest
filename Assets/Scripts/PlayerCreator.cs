using Models;
using UI.ViewControllers;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    [SerializeField] private int _startSkillPoints;
    [SerializeField] private SkillModel _baseSkill;
    [SerializeField] private PlayerViewController _playerViewController;

    public PlayerModel CreatePlayer()
    {
        var player = new PlayerModel(_baseSkill, _startSkillPoints);
        _playerViewController.Initialize(player);

        return player;
    }
}