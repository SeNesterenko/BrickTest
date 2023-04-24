using Models;
using SimpleEventBus.Events;

namespace Events
{
    public class SelectedSkillCanBeActiveEvent : EventBase
    {
        public bool CanStudySkill { get; }
        public bool CanForgetSkill { get; }
        public SkillModel SkillModel { get; }
        
        public SelectedSkillCanBeActiveEvent(bool canStudySkill, bool canForgetSkill, SkillModel skillModel)
        {
            CanStudySkill = canStudySkill;
            SkillModel = skillModel;
            CanForgetSkill = canForgetSkill;
        }
    }
}