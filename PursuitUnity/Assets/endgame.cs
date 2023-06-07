using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgame : MonoBehaviour
{
    [SerializeField] private string NomeLevel1;
    public float displayTime = 2f;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DataPersistanceManager.instance.SaveGame();
            PlayerPrefs.Save();
            EndGame();
        }
    }

    // Update is called once per frame
    void EndGame()
    {
        SceneManager.LoadScene("End");
    }
}
