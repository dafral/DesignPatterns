using UnityEngine;

namespace Patterns.Observer
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private SkillView _skillView;
        [SerializeField] private SkillViewWithEvents _skillViewWithEvents;

        private void Awake()
        {
            Skill skill = new Skill();
            _skillView.Configure(skill);

            SkillWithEvents skillWithEvents = new SkillWithEvents();
            _skillViewWithEvents.Configure(skillWithEvents);
        }
    }
}
