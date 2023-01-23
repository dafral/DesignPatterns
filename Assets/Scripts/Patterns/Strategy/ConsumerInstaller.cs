using Patterns.Adapter;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Strategy
{
    public class ConsumerInstaller : MonoBehaviour
    {
        private void Awake()
        {
            Consumer consumer = new Consumer(GetDataStore());
            consumer.Save();
            consumer.Load();
        }

        private IDataStore GetDataStore()
        {
            bool isEven = Random.Range(0, 99) % 2 == 0;
            if(isEven)
            {
                return new PlayerPrefsDataStoreAdapter();
            }

            return new FileDataStoreAdapter();
        }
    }
}
