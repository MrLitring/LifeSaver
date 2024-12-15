using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public int ScenarioID = -1;

    private void Start()
    {
        CardInformation cardInformation = transform.GetComponent<CardInformation>();
        ScenarioID = cardInformation.ScenarioID;
    }

    public void SceneLoad()
    {
        SceneWork sceneWork = SceneWork.Instance;
        sceneWork.isEditMode = false;
        SceneLoader();
    }

    public void SceneLoad(int id)
    {
        SceneWork sceneWork = SceneWork.Instance;
        if (id >= 0)
        {
            ScenarioID = id;
        }

        sceneWork.isEditMode = false;
        SceneLoader();
    }

    public void ButtonEdit()
    {
        SceneWork sceneWork = SceneWork.Instance;
        sceneWork.isEditMode = true;

        SceneLoader();
    }

    public void Delete()
    {
        SceneWork sceneWork = SceneWork.Instance;
        SqlConnect.OpenConnection();
        string sql = "Delete from Scenario where ID = " + ScenarioID;
        SqlConnect.ExecuteCommand(sql);
        SqlConnect.CloseConnection();
    }


    private void SceneLoader()
    {
        if (ScenarioID >= 0)
        {
            SceneWork sceneWork = SceneWork.Instance;
            sceneWork.ScenarioID = ScenarioID;
            sceneWork.SceneLoad();

            SceneManager.LoadScene(2);
        }
        else
        {
            throw new System.Exception("Индекс сцены не назначен на: " + gameObject.name.ToString());
        }
    }

}
