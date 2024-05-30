using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;


public class MenuManager : MonoBehaviour
{
    [SerializeField] InputField ForLogin;//Логин
    [SerializeField] InputField ForPassword;//Пароль
    [SerializeField] Text TextInformation;//информация о событии
    SqliteConnection dbconnection = 
        new SqliteConnection("Data Source = Assets/SQLFolder/mybd.bytes");//путь к вайлу в бд
    public static int idUser;

    public void GoToGame()
    {
        SqliteCommand cmd = new SqliteCommand("Select * from Users", dbconnection);
        dbconnection.Open();//подключение к бд
        var Reader = cmd.ExecuteReader();
        string log = ForLogin.text;
        string pas = ForPassword.text;
        string txt2 = "Проблема";
        while (Reader.Read())//цикл для выполнения всех значений
        {
            string Login2 = Convert.ToString(Reader[1]);
            string Password2 = Convert.ToString(Reader[2]);
            if (Login2 == log)//проверка логина
            {
                if (Password2 == pas)//проверка пароля
                {
                    txt2 = "Yes";
                    TextInformation.text = "Успешно!";
                    idUser = Convert.ToInt32(Reader[0]);
                    Debug.Log("Перемещение!");
                    SceneTransition.SwitchToScene(1);
                }
            }
        }
        if (txt2 == "Проблема")//Если пользователя не существует
        {
            TextInformation.text = "Пользователя не существует!";
        }
        Debug.Log(txt2);
        dbconnection.Close();
    }

    public void Regis()//Проверка учетных данных пользователя по существующим записям в базе данных с последующей регистрацией
    {
        SqliteCommand cmd = new SqliteCommand("Select * from Users", dbconnection);
        dbconnection.Open();//подключение к бд
        var Reader = cmd.ExecuteReader();
        string commit = null;
        int i = 1;
        while (Reader.Read())
        {
            if (Reader[1].ToString() == ForLogin.text.ToString())//Обработка ввода логина и пароля
            {
                commit = "Пароль введён неверно";
                if (Reader[2].ToString() == ForPassword.text.ToString())
                {
                    commit = "Пройдена авторизацию";
                }
            }
            i = Convert.ToInt32(Reader[0]);
        }
        if (commit == "Пройдена авторизацию")//Проверка на существующую учётную запись
        {
            TextInformation.text = "Аккаунт с таким именем существует!";
            Debug.Log("Перемещение!");
            SceneTransition.SwitchToScene(1);
        }
        if (commit == "Пароль введён неверно")
        {
            TextInformation.text = "Аккаунт с таким именем существует!";//Проверка на существующую учётную запись
        }
        if (commit != "Пройдена авторизацию")
        {
            if (commit != "Пароль введён неверно")
            {
                if (ForLogin.text.Length > 0 && ForPassword.text.Length > 0)//Обработка случая, когда необходимо создать новую учетную запись
                {
                    string sql_insert = 
                        "INSERT INTO Users (idUser,Name,Password) VALUES (" + (i + 1).ToString() + ", '" + ForLogin.text.ToString() + 
                        "', '" + ForPassword.text.ToString() + "')";
                    SqliteCommand command_insert = new SqliteCommand(sql_insert, dbconnection);//Вставка новой учетной записи в базу данных и      
                    TextInformation.text = "Новый аккаунт создан! ";//соответствующее обновление пользовательского интерфейса и объектов
                    command_insert.ExecuteNonQuery();
                    idUser = i + 1;
                    Debug.Log("Перемещение!");
                    SceneTransition.SwitchToScene(1);
                }
            }
        }
        dbconnection.Close();
    }

}
