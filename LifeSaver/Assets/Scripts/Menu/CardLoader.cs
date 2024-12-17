using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.IO;

public class CardLoader : MonoBehaviour
{
    public GameObject CardPrefabe;
    public Transform CardContainer;

    [Tooltip("Цвет при отсутствии оценки")]
    public Color NoneColor = Color.white;
    [Tooltip("Цвет отметки при оценке: grade < 50 && grade > 0")]
    public Color BadGradeColor = Color.white;
    [Tooltip("Цвет отметки при оценке: grade < 80 && grade > 50")]
    public Color GoodGradeColor = Color.white;
    [Tooltip("Цвет отметки при оценке: grade > 80")]
    public Color SuperGradeColor = Color.white;



    private void Start()
    {
        if (CardContainer == null)
            CardContainer = transform;


        CardLoad();
    }

    public void CardLoad()
    {
        string query = $"Select ID, name, description, grade, image from Scenario;";

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

    private void NewCard(int id, string textContent, int grade = 0, byte[] imageBytes = null)
    {
        GameObject card = Instantiate(CardPrefabe);
        card.transform.SetParent(CardContainer);

        CardInformation cardInfo = card.GetComponent<CardInformation>();
        cardInfo.ScenarioID = id;
        cardInfo.TextName.text = textContent;
        cardInfo.TextGrade.text = grade.ToString() + "%";
        //ByteToImage(cardInfo.image, imageBytes);
        //Debug.Log($"Image bytes length: {imageBytes?.Length}");

        Button button = cardInfo.button;
        button.onClick.AddListener(ButtonClick);

        ColorBlock colorBlock = button.colors;
        colorBlock = GradeToColor(colorBlock, grade);



        button.colors = colorBlock;
    }

    private ColorBlock GradeToColor(ColorBlock colorBlock, int grade)
    {
        if (grade > 80) colorBlock.normalColor = SuperGradeColor;
        else if (grade < 80 && grade > 50) colorBlock.normalColor = GoodGradeColor;
        else if (grade < 50 && grade > 0) colorBlock.normalColor = BadGradeColor;
        else colorBlock.normalColor = NoneColor;

        return colorBlock;
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

    private void ByteToImage(Image image, byte[] bytes = null)
    {
        if (bytes == null || bytes.Length == 0)
        {
            return; 
        }

        Texture2D texture = new Texture2D(1920, 1080);
        texture.LoadImage(bytes);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f,0.5f));

        image.sprite = sprite;
    }
}
