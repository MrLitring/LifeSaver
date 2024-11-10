using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataToSave
{
    private string tableName;
    private string columnName;
    private object value;
    private int id;



    public DataToSave(string tableName, string columnName, object value, int ID)
    {
        this.tableName = tableName;
        this.columnName = columnName;
        this.value = value;
        id = ID;
    }

    public string Query
    {
        get
        {
            return $"UPDATE {this.tableName} SET \'{this.columnName}\' = {this.value} WHERE ID = {this.id}";
        }
    }

}
