using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Observer
{
    public class SkillView : MonoBehaviour, IObserver
    {
        [SerializeField] private TextMeshProUGUI _chargesText;
        [SerializeField] private Button _skillButton;

        public void Configure(Skill skill)
        {
            _skillButton.onClick.AddListener(skill.Use);
            skill.Subscribe(this);
        }

        public void Updated(ISubject subject)
        {
            if (subject is Skill skill)
            {
                _skillButton.interactable = skill.IsReady;
                _chargesText.SetText(skill.Charges.ToString());
            }
        }
    }
}
