using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteAlways]
public class DBToObject : MonoBehaviour
{
    public string TableName = "";
    public List<Item> list = new List<Item>();
    private SceneWork sceneWork;


    private void Awake()
    {
        DataLoad();

    }

    private void Start()
    {
        DataLoad();
    }


    private void DataLoad()
    {
        if (string.IsNullOrEmpty(TableName) || list.Count == 0) return;
        sceneWork = SceneWork.Instance;

        string query = $"SELECT * FROM {TableName};";

        using (SqliteDataReader reader = SqlConnect.ExecuteReader(query))
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].ID == reader.GetInt32(0))
                        {
                            list[i].itemName = reader.GetString(1);
                            break;
                        }
                    }
                }
            }
        }

        SqlConnect.CloseConnection();

    }

}
