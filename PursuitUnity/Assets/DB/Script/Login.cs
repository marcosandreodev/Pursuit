using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    MySqlConnection con;
    private string stConexao = "Server = localhost; Database=databasegame;Uid=root;Pwd=Cdcy@015;";
    MySqlCommand cmd;

    private string nick;
    private string password;

    private void Start()
    {

    }

    private void OnGUI()
    {
        nick = GUI.TextField(Graphics.rect(0, 0, 10, 10), nick);
        password = GUI.TextField(Graphics.rect(0, 15, 40, 15), password);
        if (GUI.Button(Graphics.rect(0, 30, 30, 10), "Inserir"))
        {
            con = new MySqlConnection(stConexao);
            cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO databasegame.players (nick,senha) VALUES ('" + nick + "','" + password + "')";
            Debug.Log(cmd.CommandText);
            cmd.Connection = con;
            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}