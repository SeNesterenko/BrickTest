using Events;
using Models;
using UI.Views;
using UnityEngine;

namespace UI.ViewControllers
{
    [RequireComponent(typeof(PlayerView))]
    public class PlayerViewController : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;

        private PlayerModel _playerModel;

        public void Initialize(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _playerView.Initialize(playerModel.SkillPoints.ToString(), GetSkillPoint, ForgetAllSkills);
        }

        private void Update()
        {
            _playerView.Display(_playerModel.SkillPoints.ToString());
        }

        private void GetSkillPoint()
        {
            _playerModel.SkillPoints++;
        
        }

        private void ForgetAllSkills()
        {
            EventStreams.Game.Publish(new ForgetAllSkillsEvent());
        }
    }
}