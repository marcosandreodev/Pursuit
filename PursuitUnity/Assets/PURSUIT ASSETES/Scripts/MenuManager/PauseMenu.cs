
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseMenu;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        DataPersistanceManager.instance.SaveGame();
        PlayerPrefs.Save();
        SceneManager.LoadScene(NomeLevel);
    }
    public void RestarGame()
    {
        DataPersistanceManager.instance.NewGame();
        SceneManager.LoadScene("SecondScene");
    }
}
