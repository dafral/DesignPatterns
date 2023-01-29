using System;
using System.Collections.Generic;

namespace Patterns.Facade
{
    [Serializable]
        public class SaveData
        {
            public List<Enemy> Enemies;
            public Player Player;

            public SaveData(List<Enemy> enemies, Player player)
            {
                Enemies = enemies;
                Player = player;
            }
        }
}
