using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        gameOverUi.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuOficial");

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Jogo");
    }
}