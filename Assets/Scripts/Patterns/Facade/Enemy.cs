using System;

namespace Patterns.Facade
{
    [Serializable]
    public class Enemy : Hero
    {
        public int Stamina;

        public Enemy(int health, int stamina) : base(health)
        {
            Stamina = stamina;
        }
    }
}
