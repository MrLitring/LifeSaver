using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System;

/// <summary>
/// Класс отвечающий за работы в БД
/// <para> - OpenConnection / CloseConnection - открытие/закрытие БД </para>
/// <para> - ExecuteCommand - выполнение команды </para> 
/// <para> - ExecuteReader - Чтение, возвращает SqliteDataReader </para>
/// </summary>
public static class SqlConnect
{
    private const string fileName = "db.bytes";
    private static string dbPath;
    private static SqliteConnection connection = null;
    private static SqliteCommand command = null;


    public static SqliteConnection Connection { get { return connection; } }
    public static bool IsConnection
    {
        get
        {
            if (connection != null && connection.State == ConnectionState.Open)
                return true;
            else return false;
        }
    }


    static SqlConnect()
    {
        dbPath = GetDataBase();
        Debug.Log(dbPath);
    }

    private static string GetDataBase()
    {
        string path = Path.Combine(Application.dataPath, "Resources", fileName);

        if(File.Exists(path)) return path;

        var db = Resources.Load<TextAsset>("db");
        if(db != null)
        {
            string tempPath = Path.Combine(Application.temporaryCachePath,fileName);
            File.WriteAllBytes(tempPath, db.bytes);
            return tempPath;
        }

        return null;
    }

    public static void OpenConnection()
    {
        try
        {
            if (connection == null || IsConnection == false)
            {
                connection = new SqliteConnection("Data Source=" + dbPath);
                command = new SqliteCommand(connection);
                connection.Open();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error opening connection: " + ex.Message);
        }
    }

    public static void CloseConnection()
    {
        if (IsConnection)
        {
            connection.Close();
            command.Dispose();
        }
    }

    public static void ExecuteCommand(string query)
    {
        OpenConnection();

        Debug.Log(query);
        command.CommandText = query;
        command.ExecuteNonQuery();

        CloseConnection();
    }

    public static SqliteDataReader ExecuteReader(string query)
    {
        OpenConnection();

        command = new SqliteCommand(query, connection);
        SqliteDataReader reader = command.ExecuteReader();
        return reader;
    }

}
