using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.State
{
    public interface IEnemyState
    {
        public void Start();
        public void Stop();
        public bool Update();
        public EnemyStates GetNextState();
    }
}
