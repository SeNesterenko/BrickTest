using Events;
using Models;
using UI.Views;
using UnityEngine;

namespace UI.ViewControllers
{
    [RequireComponent(typeof(SkillView))]
    public class SkillViewController : MonoBehaviour
    {
        [SerializeField] private Color _studiedSkillColor;
        [SerializeField] private Color _notStudiedColor;
        [SerializeField] private Color _selectedColor;

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private SkillView _skillView;

        private SkillModel _skillModel;

        public void Initialize(SkillModel skillModel)
        {
            _skillModel = skillModel;
            _skillModel.IsSelected = false;
            _skillModel.IsStudied = false;
            
            _skillView.Initialize(SelectSkill, _skillModel.Name, _notStudiedColor);
            _rectTransform.localPosition = _skillModel.Position;
        }

        private void SelectSkill()
        {
            _skillModel.IsSelected = true;
            EventStreams.Game.Publish(new SkillSelectedEvent(_skillModel));
        }

        private void Update()
        {
            if (!_skillModel.IsSelected)
            {
                _skillView.Display(_skillModel.Name, _skillModel.IsStudied ? _studiedSkillColor : _notStudiedColor);
            }
            else
            {
                _skillView.Display(_skillModel.Name, _selectedColor);
            }
        }
    }
}