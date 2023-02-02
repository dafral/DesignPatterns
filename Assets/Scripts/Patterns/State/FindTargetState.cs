using System.Collections.Generic;

namespace Patterns.State
{
    public class FindTargetState : IEnemyState
    {
        private readonly Enemy _context;
        private readonly float _visionRange;
        private readonly float _sqrMaxDistance;
        private readonly ITargetFinder _targetFinder;
        private bool _enemyFound;

        public FindTargetState(Enemy context, float visionRange, ITargetFinder targetFinder)
        {
            _context = context;
            _visionRange = visionRange;
            _targetFinder = targetFinder;
            _sqrMaxDistance = visionRange * visionRange;
        }

        public void Start()
        {
            _enemyFound = false;
        }

        public bool Update()
        {
            IEnumerable<Enemy> targets = _targetFinder.FindTargets();
            foreach(Enemy target in targets)
            {
                if(target == _context)
                {
                    continue;
                }

                float sqrDistanceToTheTarget = (target.transform.position - _context.transform.position).sqrMagnitude;
                if(sqrDistanceToTheTarget > _sqrMaxDistance)
                {
                    continue;
                }

                _enemyFound = true;
                _context.EnemyToAttack = target;
            }

            return true;
        }

        public void Stop()
        {

        }

        public EnemyStates GetNextState()
        {
            return _enemyFound ? EnemyStates.MoveToTarget : EnemyStates.Idle;
        }
    }
}
