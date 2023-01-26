using System;
using UnityEngine;

namespace Patterns.Template
{
    public abstract class ActiveSkill : ScriptableObject
    {
        [SerializeField] private float _cooldownSeconds;
        private float _currentCooldown;

        public bool IsReady()
        {
            return _currentCooldown <= 0;
        }

        public void Activate(Hero hero)
        {
            DoActivate(hero);
            SetCooldown();
        }

        private void SetCooldown()
        {
            _currentCooldown = _cooldownSeconds;
        }

        public void Update()
        {
            _currentCooldown -= Time.deltaTime;
            _currentCooldown = Mathf.Max(0, _currentCooldown);
            DoUpdate();
        }

        protected abstract void DoUpdate();
        protected abstract void DoActivate(Hero hero);
    }
}
