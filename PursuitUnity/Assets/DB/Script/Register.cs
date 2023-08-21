using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public Text nameField;
    public Text passwordField;

    private string connectionString;
    private MySqlConnection con;
    private MySqlCommand cmd;
    string query;


    public void sendInfo()
    {
        Connection();

        query = "INSERT INTO databasegame.players (nick,senha) VALUES ('" + nameField.text + "','" + passwordField.text + "')";

        cmd = new MySqlCommand(query, con);

        cmd.ExecuteNonQuery();

        con.Close();
    }

    public void Connection()
    {
        connectionString = "Server = localhost; Database=databasegame;Uid=root;Pwd=Cdcy@015;";

        con = new MySqlConnection(connectionString);

        con.Open();
    }
}
