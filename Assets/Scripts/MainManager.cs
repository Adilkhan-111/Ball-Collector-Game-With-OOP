using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int HighScore;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadData();
    }


    [SerializeField]
    class Data
    {
        public int HighScore;
    }

    public void SaveData()
    {
        Data data = new Data();
        data.HighScore = HighScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/DataJSON", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/DataJSON";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);
            HighScore = data.HighScore;
        }
        
    }
}
