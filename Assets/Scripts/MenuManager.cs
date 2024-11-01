using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string playerName;
    public int playerScore;

    public string recordplayerName;
    public int recordplayerScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadName();
        Debug.Log("Player record name is: " + recordplayerName + recordplayerScore);
    }


    [System.Serializable]
    class SaveData
    {
        public string recordplayerName;
        public int recordplayerScore;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.recordplayerName = recordplayerName;
        data.recordplayerScore = recordplayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile_player_name.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile_player_name.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            recordplayerName = data.recordplayerName;
            recordplayerScore = data.recordplayerScore;
        }
    }
}
