using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skill")]
    public class SkillModel : ScriptableObject
    {
        public bool IsStudied { get; set; }
        public bool IsSelected { get; set; }
    
        public SkillModel[] NextSkills => _nextSkills;
        public SkillModel[] PreviousSkills => _previousSkills;
        public int Cost => _cost;
        public string Name => _name;
        public Vector2 Position => _position;
    
        [SerializeField] private SkillModel[] _nextSkills;
        [SerializeField] private SkillModel[] _previousSkills;
        [SerializeField] private int _cost;
        [SerializeField] private string _name;
        [SerializeField] private Vector2 _position;
    }
}