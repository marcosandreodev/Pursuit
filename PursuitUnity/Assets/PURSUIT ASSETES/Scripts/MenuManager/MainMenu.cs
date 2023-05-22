using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Start is called before the first frame update
    public void OnNewGameClicked()
    {
        DataPersistanceManager.instance.NewGame();
    }

    // Update is called once per frame
    public void OnLoadGameClicked()
    {
        DataPersistanceManager.instance.LoadGame();
    }

    public void OnSaveGameClicked()
    {
        DataPersistanceManager.instance.SaveGame();
    }
}
