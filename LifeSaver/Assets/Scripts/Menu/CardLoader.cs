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
    public Transform Container;

    private void Start()
    {
        if(Container == null)
            Container = transform;
    }

    public void CardLoad()
    {
        string query = $"Select * from Scenario;"; 

        SqliteDataReader reader = SqlConnect.ExecuteReader(query);

        if (reader.HasRows)
        {

            while (reader.Read())
            {
                NewCard(
                    reader.GetInt32(0),
                    reader.GetString(1)
                    );
            }
        }

        SqlConnect.CloseConnection();
    }

    private void NewCard(int id, string textContent, Image image = null)
    {
        GameObject card = Instantiate(CardPrefabe);
        card.transform.SetParent(Container);

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
