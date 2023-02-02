using System.Collections.Generic;

namespace Patterns.State
{
    public interface ITargetFinder
    {
        public IEnumerable<Enemy> FindTargets();
    }
}
