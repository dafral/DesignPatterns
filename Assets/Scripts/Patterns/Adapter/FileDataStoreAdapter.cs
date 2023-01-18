using UnityEngine;
using System.IO;

namespace Patterns.Adapter
{
    public class FileDataStoreAdapter : IDataStore
    {
        private const string directory = "SavedData/JSON";

        public void SetData<T>(T data, string name)
        {
            string json = JsonUtility.ToJson(data);
            string path = Path.Combine(directory, name);
            File.WriteAllText(path, json);
        }

        public T GetData<T>(string name)
        {
            string path = Path.Combine(directory, name);
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }
    }
}
