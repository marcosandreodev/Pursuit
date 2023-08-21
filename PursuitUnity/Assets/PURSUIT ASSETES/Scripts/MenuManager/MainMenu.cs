using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [Header("MenuNavigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

    [Header("Menu Buttons ")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button loadGameButton;

    public int level;
   
    private void Start()
    {
        PlayerPrefs.SetString("HasDoneTutorial", "yes");
        if (!DataPersistanceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
    }

    //Start is called before the first frame update
    public void OnNewGameClicked()
    {
        saveSlotsMenu.ActivateMenu(false);
        this.Deactivatemenu();
    }

    public void OnLoadGameClicked()
    {
        saveSlotsMenu.ActivateMenu(true);
        this.Deactivatemenu();
    }

    // Update is called once per frame
    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        DataPersistanceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("SecondScene");
         
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }

    public void Activatemenu()
    {
        this.gameObject.SetActive(true);
    }
    public void Deactivatemenu()
    {
        this.gameObject.SetActive(false);
    }
}
