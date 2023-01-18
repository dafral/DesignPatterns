
using UnityEngine;

namespace Patterns.Adapter
{
    public class PlayerPrefsDataStoreAdapter : IDataStore
    {
        public void SetData<T>(T data, string name)
        {
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(name, json);
            PlayerPrefs.Save();
        }

        public T GetData<T>(string name)
        {
            string json = PlayerPrefs.GetString(name);
            return JsonUtility.FromJson<T>(json);
        }
    }
}
