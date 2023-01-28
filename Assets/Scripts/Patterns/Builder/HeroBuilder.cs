using UnityEngine;

namespace Patterns.Builder
{
    public class HeroBuilder
    {
        private Hero _prefab;
        private Weapon _weapon;
        private Armor _armor;

        public HeroBuilder WithArmor(Armor armor)
        {
            _armor = armor;
            return this;
        }

        public HeroBuilder WithWeapon(Weapon weapon)
        {
            _weapon = weapon;
            return this;
        }

        public HeroBuilder FromHeroPrefab(Hero prefab)
        {
            _prefab = prefab;
            return this;
        }

        public Hero Build()
        {
            Hero hero = Object.Instantiate(_prefab);
            Weapon weapon = Object.Instantiate(_weapon, hero.transform);
            Armor armor = Object.Instantiate(_armor, hero.transform);
            hero.SetComponents(weapon, armor);

            return hero;
        }
    }
}
