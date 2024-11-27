using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCalculation : MonoBehaviour
{
    public TextMeshProUGUI grade;
    public GameObject gradePanel;

    public TextMeshProUGUI TrueAnswerText;
    public TextMeshProUGUI FalseAnswerText;

    public void Show()
    {
        TrueAnswerText.text = string.Empty;
        FalseAnswerText.text = string.Empty;

        grade.text = Mathf.Min(SceneWork.Instance.score, 100).ToString() + " %";

        gradePanel.GetComponent<Image>().fillAmount = SceneWork.Instance.score / 100f;
        Debug.Log($"ќценка: {SceneWork.Instance.score} => {SceneWork.Instance.score / 100f}");

        foreach(string elem in SceneWork.Instance.TrueAnswer)
        {
            TrueAnswerText.text += elem + "\n";
        }

        foreach (string elem in SceneWork.Instance.FalseAnswer)
        {
            FalseAnswerText.text += elem + "\n";
        }

    }

    public void Save()
    {
        SqlConnect.OpenConnection();

        DataToSave dataToSave = new DataToSave("Scenario", "grade", Mathf.Min(SceneWork.Instance.score, 100), SceneWork.Instance.ScenarioID);
        SqlConnect.ExecuteCommand(dataToSave.Query);

        SqlConnect.CloseConnection();
    }


    public void NextScene()
    {
        MenuLoader menuLoader = new MenuLoader();
        menuLoader.SceneLoad(SceneWork.Instance.ScenarioIDNext);
    }

}
