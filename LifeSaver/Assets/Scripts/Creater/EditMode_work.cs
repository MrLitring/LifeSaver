using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class EditMode_work : MonoBehaviour
{
    SceneWork SceneWork;

    public TextMeshProUGUI[] TextArea = new TextMeshProUGUI[0];

    public void Save()
    {
        SaveData();
    }

    public void SaveAs()
    {
        SqlConnect.OpenConnection();
        SqliteDataReader reader = SqlConnect.ExecuteReader(SQLSelect.LastEntry("Scenario", "ID", "ID"));
        if(reader.HasRows == true)
        {
            SceneWork.ScenarioID = reader.GetInt32(0);
        }
        else
        {
            SceneWork.ScenarioID = 1;
        }
        SqlConnect.CloseConnection();

        SaveData();
    }

    public void Delete()
    {
        SqlConnect.OpenConnection();
        SqlConnect.ExecuteCommand($"Delete from Scenario where ID = {SceneWork.ScenarioID}");
        SqlConnect.CloseConnection();
    }

    public void Cancer()
    {

    }

    public void OnCollisionExit(Collision collision)
    {

    }



    private void SaveData()
    {
        SqlConnect.OpenConnection();
        Debug.Log(TextArea[0].text);
        SqlConnect.CloseConnection();
    }

    private string SQLQuery()
    {
        return "";
    }

    
}
