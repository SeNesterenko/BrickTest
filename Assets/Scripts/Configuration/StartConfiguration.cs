using Models;
using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "StartConfiguration", menuName = "StartConfiguration")]
    public class StartConfiguration : ScriptableObject
    {
        public SkillModel[] SkillModels => _skillModels;
    
        [SerializeField] private SkillModel[] _skillModels;
    }
}