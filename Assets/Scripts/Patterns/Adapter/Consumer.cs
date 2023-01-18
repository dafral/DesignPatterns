using UnityEngine;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        private IDataStore _fileDataStoreAdapter;

        private void Awake()
        {
            _fileDataStoreAdapter = new PlayerPrefsDataStoreAdapter();
            Data data = new Data("Element", 1);
            _fileDataStoreAdapter.SetData(data, "Data1");
        }

        private void Start()
        {
            Data data = _fileDataStoreAdapter.GetData<Data>("Data1");
            Debug.Log(data.Element1);
            Debug.Log(data.Element2);
        }
    }
}
