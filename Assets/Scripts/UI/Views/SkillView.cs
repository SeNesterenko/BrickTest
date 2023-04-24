using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Views
{
    public class SkillView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textName;
        [SerializeField] private Image _image;
        [SerializeField] private Button _selectSkillButton;

        public void Initialize(UnityAction skillButtonSelected, string skillName, Color color)
        {
            _selectSkillButton.onClick.AddListener(skillButtonSelected);
            Display(skillName, color);
        }
        
        public void Display(string skillName, Color color)
        {
            _textName.text = skillName;
            _image.color = color;
        }
    }
}