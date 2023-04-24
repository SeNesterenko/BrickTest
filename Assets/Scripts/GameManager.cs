using Configuration;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GraphCreator _graphCreator;
    [SerializeField] private PlayerCreator _playerCreator;
    
    [SerializeField] private StartConfiguration _startConfiguration;

    private PlayerSkillsHandler _playerSkillsHandler;
    
    private void Awake()
    {
        _graphCreator.GenerateGraph(_startConfiguration.SkillModels);
        _playerSkillsHandler = new PlayerSkillsHandler(_playerCreator.CreatePlayer());
    }

    private void OnDestroy()
    {
        _playerSkillsHandler.Dispose();
    }
}