using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;


public static class SqlConnect
{
    private const string fileName = "db.bytes";
    private static string dbPath;
    private static SqliteConnection connection = null;
    private static SqliteCommand command = null;


    public static SqliteConnection Connection { get { return connection; } }


    static SqlConnect()
    {
        dbPath = GetDataBase();
        Debug.Log(dbPath);
    }

    private static string GetDataBase()
    {
        return Path.Combine(Application.dataPath, "Data Base" ,fileName);
    }

    public static void OpenConnection()
    {
        connection = new SqliteConnection("Data Source=" + dbPath);
        command = new SqliteCommand(connection);
        connection.Open();

    }

    public static void CloseConnection()
    {
        connection.Close();
        command.Dispose();
    }

    public static void ExecuteCommand(string query)
    {
        OpenConnection();
        command.CommandText = query;
        command.ExecuteNonQuery();
        CloseConnection();

    }

    public static SqliteDataReader ExecuteReader(string query)
    {
        if (IsConnection() == false) OpenConnection();

        command = new SqliteCommand(query, connection);
        SqliteDataReader reader = command.ExecuteReader();
        return reader;
    }

    public static bool IsConnection()
    {
        if(connection != null && connection.State == ConnectionState.Open)
            return true;
        else return false;
    }
}
