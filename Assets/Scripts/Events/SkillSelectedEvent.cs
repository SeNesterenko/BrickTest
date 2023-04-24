using Models;
using SimpleEventBus.Events;

namespace Events
{
    public class SkillSelectedEvent : EventBase
    {
        public SkillModel SkillModel { get; }

        public SkillSelectedEvent(SkillModel skillModel)
        {
            SkillModel = skillModel;
        }
    }
}