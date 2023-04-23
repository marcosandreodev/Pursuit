using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public Transform deadMenu;
    public PlayerHealth pHealth;
    [SerializeField] private string NomeLevel;
    [SerializeField] private string NomeCena1;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (deadMenu.gameObject.activeSelf)
        {
            deadMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            deadMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(NomeLevel);
        
    }
}
