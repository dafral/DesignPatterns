using UnityEngine;

namespace Patterns.State
{
    public class MoveToTargetState : IEnemyState
    {
        private readonly Enemy _context;
        private readonly float _movementSpeed;
        private readonly float _sqrMinDistanceToAttack;

        public MoveToTargetState(Enemy context, float movementSpeed, float sqrMinDistanceToAttack)
        {
            _context = context;
            _movementSpeed = movementSpeed;
            _sqrMinDistanceToAttack = sqrMinDistanceToAttack;
        }

        public void Start()
        {

        }

        public bool Update()
        {
            Enemy target = _context.EnemyToAttack;
            if(target == null)
            {
                return true;
            }

            Vector3 distanceToTheTarget = target.transform.position - _context.transform.position;
            if(distanceToTheTarget.sqrMagnitude > _sqrMinDistanceToAttack)
            {
                _context.transform.Translate(distanceToTheTarget.normalized * (_movementSpeed * Time.deltaTime));
            }

            return distanceToTheTarget.sqrMagnitude <= _sqrMinDistanceToAttack;
        }

        public void Stop()
        {

        }

        public EnemyStates GetNextState()
        {
            return _context.EnemyToAttack != null ? EnemyStates.Attack : EnemyStates.Idle;
        }
    }
}
