using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.State
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _idleTime = 2f;
        [SerializeField] private float _visionRange = 20f;
        [SerializeField] private float _minDistanceToAttack = 2f;
        [SerializeField] private float _movementSpeed = 2f;
        [SerializeField] private int _attackDamage = 2;

        private IEnemyState _currentState;
        private Dictionary<EnemyStates, IEnemyState> _idToState;

        public Enemy EnemyToAttack { get; internal set; }

        private void Awake()
        {
            _idToState =
                new Dictionary<EnemyStates, IEnemyState>
                {
                    {EnemyStates.Idle, new IdleState(this, _idleTime) },
                    {EnemyStates.FindTarget, new FindTargetState(this, _visionRange, new TargetFinderStrategy()) },
                    {EnemyStates.MoveToTarget, new MoveToTargetState(this, _minDistanceToAttack, _movementSpeed) },
                    {EnemyStates.Attack, new AttackToTargetState(this, _attackDamage) }
                };
        }

        private void Start()
        {
            _currentState = GetState(EnemyStates.Idle);
            _currentState.Start();
        }

        private void Update()
        {
            if(_currentState.Update())
            {
                NextState();
            }
        }

        private void NextState()
        {
            _currentState.Stop();
            _currentState = GetState(_currentState.GetNextState());
            _currentState.Start();
        }

        private IEnemyState GetState(EnemyStates state)
        {
            return _idToState[state];
        }

        public void DoDamage(float damageToApply)
        {
            Debug.Log($"Receive damage: {name}");
        }
    }
}
