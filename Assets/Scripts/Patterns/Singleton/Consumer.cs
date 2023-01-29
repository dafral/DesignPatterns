using System.Collections;
using UnityEngine;

namespace Patterns.Singleton
{
    public class Consumer : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(AddPoints());
        }

        private IEnumerator AddPoints()
        {
            for (int i = 0; i < 5; i++)
            {
                ScoreSystemMonoBehaviourSerialized.Instance().AddScore(100);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
