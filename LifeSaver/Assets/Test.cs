using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public CardLoader loader;

    void Start()
    {
        //SqlConnect.OpenConnection();
        //Debug.Log(SqlConnect.IsConnection().ToString());
        //string sql = "Insert into Items Values (1, 'Аптечка', 'Блаблаблабла')";
        //SqlConnect.ExecuteCommand(sql);
        //SqlConnect.CloseConnection();

        loader.CardLoad();
    }

}
