using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerCalculation : MonoBehaviour
{
    public GameObject AnswerMessage;
    public TextMeshProUGUI grade;


    public void Show()
    {
        AnswerMessage.SetActive(true);
        grade.text = SceneWork.Instance.score.ToString() + " %";

        SqlConnect.OpenConnection();

        DataToSave dataToSave = new DataToSave("Scenario", "grade", SceneWork.Instance.score, SceneWork.Instance.ScenarioID);
        SqlConnect.ExecuteCommand(dataToSave.Query);

        SqlConnect.CloseConnection();
    }


    public void NextScene()
    {
        MenuLoader menuLoader = new MenuLoader();
        SceneWork.Instance.ScenarioID = SceneWork.Instance.ScenarioIDNext;
        menuLoader.SceneLoad();
    }

}
