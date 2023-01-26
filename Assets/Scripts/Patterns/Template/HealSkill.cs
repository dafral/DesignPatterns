using UnityEngine;

namespace Patterns.Template
{
    [CreateAssetMenu(menuName = "Template/Create HealSkill", fileName ="HealSkill", order = 0)]
    public class HealSkill : ActiveSkill
    {
        [SerializeField] private int _healthToAdd;
        protected override void DoActivate(Hero hero)
        {
            hero.AddHealth(_healthToAdd);
        }

        protected override void DoUpdate() 
        {}
    }
}
