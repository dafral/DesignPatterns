using System;

namespace Patterns.State
{
    public class AttackToTargetState : IEnemyState
    {
        private readonly Enemy _context;
        private readonly float _damageToApply;

        public AttackToTargetState(Enemy context, float damageToApply)
        {
            _context = context;
            _damageToApply = damageToApply;
        }

        public void Start()
        {

        }

        public bool Update()
        {
            if (_context.EnemyToAttack != null)
            {
                _context.EnemyToAttack.DoDamage(_damageToApply);
            }

            return true;
        }

        public void Stop()
        {

        }

        public EnemyStates GetNextState()
        {
            return EnemyStates.Idle;
        }
    }
}
