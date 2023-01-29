using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Patterns.Adapter;

namespace Patterns.Facade
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<Enemy> Enemies = new List<Enemy>
        {
            new Enemy(50, 50),
            new Enemy(50, 50)
        };
    }
}
