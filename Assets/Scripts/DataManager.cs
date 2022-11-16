using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public int score;

    string jsonHiScore;
    string jsonScore;

    public SaveData playerData = new SaveData();

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [System.Serializable] 
    public class SaveData
    {
        public string playerName;
        public int score = 0;
    }

    public void SaveScore()
    {
        LoadScore();
        if(score > playerData.score)
        {
            SaveData dataToSave = new SaveData();
            dataToSave.playerName = playerName;
            dataToSave.score = score;
            jsonScore = JsonUtility.ToJson(dataToSave);
            File.WriteAllText(Application.persistentDataPath + "/savefilePersistance.json", jsonScore);
        }       
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefilePersistance.json";
        if(File.Exists(path))
        {
            jsonHiScore = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<SaveData>(jsonHiScore);
        }
    }
}
