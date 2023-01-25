using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;

        private const float secondsToDestroy = 4f;

        public string Id => _id;

        private void Start()
        {
            _rigidbody.velocity = transform.up * _speed;
            StartCoroutine(DestroyIn(secondsToDestroy));
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}
