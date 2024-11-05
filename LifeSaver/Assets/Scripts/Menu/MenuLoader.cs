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
        if (ScenarioID >= 0)
        {
            SceneWork sceneWork = SceneWork.Instance;
            sceneWork.ScenarioID = ScenarioID;
            sceneWork.SceneLoad();

            SceneManager.LoadScene(1);
        }
        else
        {
            throw new System.Exception("Индекс сцены не назначен на: " + gameObject.name.ToString());
        }

    }

}
