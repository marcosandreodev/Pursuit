using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    public int level;

    public void Start()
    {
        
    }

    public void ValidateLevel(GameData data)
    {
        data.level = level;
        UpdateLevel();
    }

    public void UpdateLevel()
    {

        if(level == 1) 
        {
            SceneManager.LoadScene("SecondScene");  
        }
    }

}
