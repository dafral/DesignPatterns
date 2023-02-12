using UnityEngine;

namespace Core.DataStorage
{
    public class DataStorage
    {
        public UserData GetScores()
        {
            string json = PlayerPrefs.GetString("BestScores");
            return JsonUtility.FromJson<UserData>(json);
        }

        public void UpdateScore(UserData userData)
        {
            string json = JsonUtility.ToJson(userData);
            PlayerPrefs.SetString("BestScores", json);
            PlayerPrefs.Save();
        }
    }
}
