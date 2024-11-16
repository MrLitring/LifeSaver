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
    public int ScenarioIDNext = -1;
    public string SceneName = string.Empty;
    public string SceneDescription = string.Empty;
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
        string sql = $"Select * from Scenario;";

        SqliteDataReader reader = SqlConnect.ExecuteReader(sql);

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if(ScenarioID == reader.GetInt32(0))
                {
                    DataRead(reader);

                    if (reader.Read())
                    {
                        ScenarioIDNext = reader.GetInt32(0);
                    }
                    else
                        ScenarioIDNext = -1;

                    break;
                }
            }
        }

        SqlConnect.CloseConnection();
        scoreStep = StepCalc();
    }

        public void Reset()
    {
        ScenarioIDNext = -1;

        SceneName = "None";
        SceneDescription = "None";

        items.Clear();
        collisions.Clear();
        actions.Clear();

        pose =-1;
        spawnPoint = -1;

        score = 0;
        scoreStep = 0;
    }


    public string GetString(string name)
    {
        string text = string.Empty;

        switch(name)
        {
            case "SceneName": text = SceneName; break;
            case "SceneDescription": text = SceneDescription; break;

            case "Settings":
                {
                    text = $"Для перемещения используйте \r\nклавишы:\r\n{KeyboardSettings.Left} - влево;\r\n{KeyboardSettings.MoveForward} - вперед;\r\n{KeyboardSettings.MoveBack} - назад;\r\n{KeyboardSettings.Right} - вправо." +
                        $"\r\n\r\nДля поворота камерой используйте компьютерную мышь." +
                        $"\r\n\r\n{KeyboardSettings.Interactble} - подобрать/применить предмет.\r\n{KeyboardSettings.Drop} - выбросить предмет." +
                        $"\r\n\r\n{KeyboardSettings.Alpha1},{KeyboardSettings.Alpha2},{KeyboardSettings.Alpha3},{KeyboardSettings.Alpha4},{KeyboardSettings.Alpha5} - клавишы выбора слота в инвентаре.";

                    break;
                }
        }


    return text;
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
        if (string.IsNullOrEmpty(text)) return new List<int>();

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

        return (100 / Mathf.Max(score, 1));
    }
}
