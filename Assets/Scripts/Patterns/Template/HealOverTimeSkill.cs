using UnityEngine;

namespace Patterns.Template
{
    [CreateAssetMenu(menuName = "Template/Create HealOverTimeSkill", fileName = "HealOverTimeSkill", order = 1)]
    public class HealOverTimeSkill : ActiveSkill
    {
        [SerializeField] private float _activeTimeInSeconds;
        [SerializeField] private int _healthToAdd;

        private Hero _hero;
        private float _currentTimeInSeconds;
        private bool _isActive;
        

        protected override void DoActivate(Hero hero)
        {
            _isActive = true;
            _currentTimeInSeconds = 0;
            _hero = hero;
        }

        protected override void DoUpdate()
        {
            if (!_isActive)
            {
                return;
            }

            _hero.AddHealth(_healthToAdd * Time.deltaTime);

            _currentTimeInSeconds += Time.deltaTime;
            if(_currentTimeInSeconds > _activeTimeInSeconds)
            {
                _isActive = false;
                return;
            }
        }
    }
}
