using System.Collections.Generic;

namespace Models
{
    public class PlayerModel
    {
        public int SkillPoints { get; set; }
        public HashSet<SkillModel> Skills { get; }

        public PlayerModel(SkillModel baseSkill, int startSkillPoints)
        {
            SkillPoints = startSkillPoints;
            Skills = new HashSet<SkillModel>
            {
                baseSkill
            };
        }
    }
}