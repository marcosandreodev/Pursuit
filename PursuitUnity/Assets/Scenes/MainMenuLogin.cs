using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogin : MonoBehaviour {

   public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
}
