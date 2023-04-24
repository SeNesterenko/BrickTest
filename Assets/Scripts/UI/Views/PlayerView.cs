using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _skillPointsText;
        [SerializeField] private Button _getSkillPointButton;
        [SerializeField] private Button _forgetAllButton;

        public void Initialize(string skillPoints, UnityAction getSkillPointClicked, UnityAction allSkillForgetClicked)
        {
            _getSkillPointButton.onClick.AddListener(getSkillPointClicked);
            _forgetAllButton.onClick.AddListener(allSkillForgetClicked);
            Display(skillPoints);
        }

        public void Display(string skillPoints)
        {
            _skillPointsText.text = "Очки: " + skillPoints;
        }
    }
}