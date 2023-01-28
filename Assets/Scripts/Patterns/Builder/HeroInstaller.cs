using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Builder
{
    public class HeroInstaller : MonoBehaviour
    {
        [Header("Assets")]
        [SerializeField] private Armor _normalArmor;
        [SerializeField] private Armor _reflectiveArmor;
        [SerializeField] private Weapon _bow;
        [SerializeField] private Weapon _sword;
        [SerializeField] private Hero _heroPrefab;

        [Header("Buttons")]
        [SerializeField] private Button _normalArmorButton;
        [SerializeField] private Button _reflectiveArmorButton;
        [SerializeField] private Button _bowButton;
        [SerializeField] private Button _swordButton;
        [SerializeField] private Button _buildButton;

        private HeroBuilder _heroBuilder;
        private GameObject _currentHero;

        private void Awake()
        {
            _heroBuilder = new HeroBuilder().FromHeroPrefab(_heroPrefab);

            _normalArmorButton.onClick.AddListener(() => _heroBuilder.WithArmor(_normalArmor));
            _reflectiveArmorButton.onClick.AddListener(() => _heroBuilder.WithArmor(_reflectiveArmor));
            _bowButton.onClick.AddListener(() => _heroBuilder.WithWeapon(_bow));
            _swordButton.onClick.AddListener(() => _heroBuilder.WithWeapon(_sword));
            _buildButton.onClick.AddListener(InstantiateHero);
        }

        private void InstantiateHero()
        {
            if(_currentHero != null)
            {
                Destroy(_currentHero);
            }

            _currentHero = _heroBuilder.Build().gameObject;
        }
    }
}
