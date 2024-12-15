using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SQLSelect 
{
    public static string LastEntry(string tableName, string columnName)
    {
        return $"SELECT * FROM {tableName} ORDER BY {columnName} DESC LIMIT 1;";
    }

    public static string LastEntry(string tableName, string columnName, string needEntry)
    {
        return $"SELECT {needEntry} FROM {tableName} ORDER BY {columnName} DESC LIMIT 1;";
    }
}
