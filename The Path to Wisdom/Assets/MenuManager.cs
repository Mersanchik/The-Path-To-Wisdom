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
    [SerializeField] InputField ForLogin;//�����
    [SerializeField] InputField ForPassword;//������
    [SerializeField] Text TextInformation;//���������� � �������
    SqliteConnection dbconnection = 
        new SqliteConnection("Data Source = Assets/SQLFolder/mybd.bytes");//���� � ����� � ��
    public static int idUser;

    public void GoToGame()
    {
        SqliteCommand cmd = new SqliteCommand("Select * from Users", dbconnection);
        dbconnection.Open();//����������� � ��
        var Reader = cmd.ExecuteReader();
        string log = ForLogin.text;
        string pas = ForPassword.text;
        string txt2 = "��������";
        while (Reader.Read())//���� ��� ���������� ���� ��������
        {
            string Login2 = Convert.ToString(Reader[1]);
            string Password2 = Convert.ToString(Reader[2]);
            if (Login2 == log)//�������� ������
            {
                if (Password2 == pas)//�������� ������
                {
                    txt2 = "Yes";
                    TextInformation.text = "�������!";
                    idUser = Convert.ToInt32(Reader[0]);
                    Debug.Log("�����������!");
                    SceneTransition.SwitchToScene(1);
                }
            }
        }
        if (txt2 == "��������")//���� ������������ �� ����������
        {
            TextInformation.text = "������������ �� ����������!";
        }
        Debug.Log(txt2);
        dbconnection.Close();
    }

    public void Regis()//�������� ������� ������ ������������ �� ������������ ������� � ���� ������ � ����������� ������������
    {
        SqliteCommand cmd = new SqliteCommand("Select * from Users", dbconnection);
        dbconnection.Open();//����������� � ��
        var Reader = cmd.ExecuteReader();
        string commit = null;
        int i = 1;
        while (Reader.Read())
        {
            if (Reader[1].ToString() == ForLogin.text.ToString())//��������� ����� ������ � ������
            {
                commit = "������ ����� �������";
                if (Reader[2].ToString() == ForPassword.text.ToString())
                {
                    commit = "�������� �����������";
                }
            }
            i = Convert.ToInt32(Reader[0]);
        }
        if (commit == "�������� �����������")//�������� �� ������������ ������� ������
        {
            TextInformation.text = "������� � ����� ������ ����������!";
            Debug.Log("�����������!");
            SceneTransition.SwitchToScene(1);
        }
        if (commit == "������ ����� �������")
        {
            TextInformation.text = "������� � ����� ������ ����������!";//�������� �� ������������ ������� ������
        }
        if (commit != "�������� �����������")
        {
            if (commit != "������ ����� �������")
            {
                if (ForLogin.text.Length > 0 && ForPassword.text.Length > 0)//��������� ������, ����� ���������� ������� ����� ������� ������
                {
                    string sql_insert = 
                        "INSERT INTO Users (idUser,Name,Password) VALUES (" + (i + 1).ToString() + ", '" + ForLogin.text.ToString() + 
                        "', '" + ForPassword.text.ToString() + "')";
                    SqliteCommand command_insert = new SqliteCommand(sql_insert, dbconnection);//������� ����� ������� ������ � ���� ������ �      
                    TextInformation.text = "����� ������� ������! ";//��������������� ���������� ����������������� ���������� � ��������
                    command_insert.ExecuteNonQuery();
                    idUser = i + 1;
                    Debug.Log("�����������!");
                    SceneTransition.SwitchToScene(1);
                }
            }
        }
        dbconnection.Close();
    }

}
