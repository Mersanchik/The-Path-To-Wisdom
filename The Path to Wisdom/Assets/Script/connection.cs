using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;
using UnityEngine.UI;

public class connection : MonoBehaviour
{
    SqliteConnection dbconnection = new SqliteConnection("Data Source = Assets/SQLFolder/mybd.bytes");
    private string path;
    //public InputField ForLogin;//Логин
    //public InputField ForPassword;//Пароль

    public void setConnection()
    {
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = dbconnection;
            cmd.CommandText = "SELECT * FROM Users";
            SqliteDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Debug.Log(string.Format("{0} {1}", r[0], r[1]));
            }
        }
        else
        {
            Debug.Log("Error!");
        }
    }

    
}
