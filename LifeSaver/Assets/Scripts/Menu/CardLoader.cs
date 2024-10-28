using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class CardLoader : MonoBehaviour
{
    public GameObject CardPrefabe;
    public Transform CardContainer;

    private void Start()
    {
        if(CardContainer == null)
            CardContainer = transform;
    }

    public void CardLoad()
    {
        string query = $"Select ID, name, description, grade from Scenario;";

        SqlConnect.OpenConnection();
        SqliteDataReader reader = SqlConnect.ExecuteReader(query);
        int i = 0;

        if (reader.HasRows)
        {
            int grade = 0;

            while (reader.Read())
            {
                grade = 0;
                if (!reader.IsDBNull(3)) grade = reader.GetInt32(3);

                NewCard(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    grade
                    );
                i++;
            }
        }

        SqlConnect.CloseConnection();

        ResizeContainer(i);

    }

    private void NewCard(int id, string textContent, int grade = 0,Image image = null)
    {
        GameObject card = Instantiate(CardPrefabe);
        card.transform.SetParent(CardContainer);

        CardInformation cardInfo =  card.GetComponent<CardInformation>();
        cardInfo.ScenarioID = id;
        cardInfo.TextName.text = textContent;
        cardInfo.TextGrade.text = grade.ToString();
        cardInfo.image = ByteToImage();

        Button button = cardInfo.button;
        button.onClick.AddListener(ButtonClick);

        ColorBlock colorBlock = button.colors;

        if(grade > 70) colorBlock.normalColor = Color.green;
        else if (grade < 70 && grade > 50) colorBlock.normalColor = Color.yellow;
        else if (grade < 50 && grade > 0) colorBlock.normalColor = Color.red;
        else colorBlock.normalColor = Color.gray;

        button.colors = colorBlock;
    }

    private void ResizeContainer(int colElements)
    {
       colElements = colElements / 4;
        RectTransform rectTransform = CardContainer.GetComponent<RectTransform>();
        Vector2 size = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
        size.y = colElements * 350 + colElements * 20 + 350 * 3 - 40;

        rectTransform.sizeDelta = size;
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -size.y / 2);
    }

    private void ButtonClick()
    {


    }

    private Image ByteToImage(byte[] bytes = null)
    {
        Image image = null;

        return image;
    }
}
