using Models;
using SimpleEventBus.Events;

namespace Events
{
    public class SkillForgetEvent : EventBase
    {
        public SkillModel SkillModel { get; }
        
        public SkillForgetEvent(SkillModel skillModel)
        {
            SkillModel = skillModel;
        }
    }
}