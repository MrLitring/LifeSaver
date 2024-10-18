using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

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
        string query = $"Select * from Scenario;"; 

        SqliteDataReader reader = SqlConnect.ExecuteReader(query);
        int i = 0;

        if (reader.HasRows)
        {

            while (reader.Read())
            {
                NewCard(
                    reader.GetInt32(0),
                    reader.GetString(1)
                    );
                i++;
            }
        }

        SqlConnect.CloseConnection();

        i = i / 4;
        RectTransform rectTransform = CardContainer.GetComponent<RectTransform>();
        Vector2 size = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
        size.y = i * 350 + i * 20 + 350 * 3 - 40;
        Debug.Log(size);

        rectTransform.sizeDelta = size;
        Debug.Log(rectTransform.anchoredPosition);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -size.y/2);
    }

    private void NewCard(int id, string textContent, Image image = null)
    {
        GameObject card = Instantiate(CardPrefabe);
        card.transform.SetParent(CardContainer);

        CardInformation cardInfo =  card.GetComponent<CardInformation>();
        cardInfo.ID = id;
        if (cardInfo.FirstText != null) cardInfo.FirstText.text = textContent;
        if (cardInfo.image != null) cardInfo.image = ByteToImage();

        
    }

    private Image ByteToImage(byte[] bytes = null)
    {
        Image image = null;

        return image;
    }
}
