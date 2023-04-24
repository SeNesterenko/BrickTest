using Models;
using SimpleEventBus.Events;

namespace Events
{
    public class SkillStudyEvent : EventBase
    {
        public SkillModel SkillModel { get; }

        public SkillStudyEvent(SkillModel skillModel)
        {
            SkillModel = skillModel;
        }
    }
}