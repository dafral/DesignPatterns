using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Observer
{
    public class SkillViewWithEvents : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _chargesText;
        [SerializeField] private Button _skillButton;

        public void Configure(ISkill skill)
        {
            _skillButton.onClick.AddListener(skill.Use);

            skill.OnChargesUpdated += charges => _chargesText.SetText(charges.ToString());
            skill.OnIsReadyUpdated += isReady => _skillButton.interactable = isReady;
        }
    }
}
