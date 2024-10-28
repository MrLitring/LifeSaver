using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneWork : MonoBehaviour
{
    private static SceneWork _instance;
    public static SceneWork Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindAnyObjectByType<SceneWork>();

                if (_instance == null)
                {
                    GameObject singlTone = new GameObject();
                    _instance = singlTone.AddComponent<SceneWork>();

                }
            }

            return _instance;
        }
    }


    public int ScenarioID = -1;
    public string SceneName = string.Empty;
    public string SceneDescription = string.Empty;
    //public string SceneVersion;
    public List<int> items = new List<int>();
    public List<int> collisions = new List<int>();
    public List<int> actions = new List<int>();
    public int pose = 1;
    public int spawnPoint = 1;

    public float scoreStep = 0;
    public float score = 0;



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        SceneLoad();
    }



    public void SceneLoad()
    {
        SqlConnect.OpenConnection();
        string sql = "Select * from scenario";

        SqliteDataReader reader = SqlConnect.ExecuteReader(sql);

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if(ScenarioID == reader.GetInt32(0))
                {
                    DataRead(reader);
                    
                }
            }
        }

        SqlConnect.CloseConnection();
        scoreStep = StepCalc();
    }


    private void DataRead(SqliteDataReader reader)
    {
        try
        { 
            SceneName = reader.GetString(1);
            SceneDescription = reader.GetString(2);

            items = DataSeparatesToInt(reader.GetString(4));
            collisions = DataSeparatesToInt(reader.GetString(5));
            actions = DataSeparatesToInt(reader.GetString(6));

            pose = reader.GetInt32(7);
            spawnPoint = reader.GetInt32(8);
        }
        catch { Debug.LogWarning("Ошибка при чтении БД Scenario для " + ScenarioID.ToString()); }
        }

    private List<int> DataSeparatesToInt(string text, string sepChar = " ")
    {
        if (text == null || text == string.Empty) return null;

        List<int> list = new List<int>();
        string[] split = text.Split(new string[] { sepChar }, StringSplitOptions.RemoveEmptyEntries);


        for (int i = 0; i < split.Length; i++)
        {
            list.Add(int.Parse(split[i]));
        }

        return list;
    }

    private float StepCalc()
    {
        int score = items.Count + actions.Count;
        if (score == 0) score = 1;

        return (100 / (float)score);
    }
}
