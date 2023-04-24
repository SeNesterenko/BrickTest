using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Views
{
    public class SkillInputView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _costSkillText;
    
        [SerializeField] private Button _forgetSkillButton;
        [SerializeField] private Button _studySkillButton;

        public void Initialize(UnityAction onStudySkillButtonClicked, UnityAction onForgetSkillButtonClicked)
        {
            _studySkillButton.onClick.AddListener(onStudySkillButtonClicked);
            _forgetSkillButton.onClick.AddListener(onForgetSkillButtonClicked);
            _costSkillText.text = "Не выбрано";
        }

        public void ResetButtons(bool canForgetSkill, bool canStudySkill)
        {
            if (!canForgetSkill)
            {
                _forgetSkillButton.interactable = false;
            }

            if (!canStudySkill)
            {
                _studySkillButton.interactable = false;
            }
        }

        public void DisplayPossibilityStudySkill(string costSkill)
        {
            _costSkillText.text = "Цена: " + costSkill;
            _studySkillButton.interactable = true;
        }

        public void DisplayPossibilityForgetSkill()
        {
            _forgetSkillButton.interactable = true;
        }
    }
}