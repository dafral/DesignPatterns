using System.Collections.Generic;
using UnityEngine;

namespace Patterns.State
{
    public class TargetFinderStrategy : ITargetFinder
    {
        public IEnumerable<Enemy> FindTargets()
        {
            return Object.FindObjectsOfType<Enemy>();
        }
    }
}
