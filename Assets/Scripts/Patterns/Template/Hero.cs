using System;
using UnityEngine;

namespace Patterns.Template
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private ActiveSkill _skill1;
        [SerializeField] private ActiveSkill _skill2;
        [SerializeField] private float _maxHealth;

        private float _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth / 2;
        }

        public void AddHealth(float healthToAdd)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + healthToAdd, 0, _maxHealth);
            Debug.Log($"Current health: {_currentHealth}");
        }

        private void Update()
        {
            UpdateSkills();
            TryUseSkills();
        }

        private void UpdateSkills()
        {
            _skill1.Update();
            _skill2.Update();
        }

        private void TryUseSkills()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                TryUseSkill(_skill1);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                TryUseSkill(_skill2);
            }
        }

        private void TryUseSkill(ActiveSkill skill)
        {
            if(skill.IsReady())
            {
                skill.Activate(this);
            }
        }
    }
}
