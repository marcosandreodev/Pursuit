using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpmenu : MonoBehaviour
{
    public bool haskey;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HasDoneTutorial"))
        {
            SceneManager.LoadScene("MenuOficial");
        }
        else
        {
            SceneManager.LoadScene("FirstScene");
        }
    }

    private void Update()
    {
        
    }

    // Update is called once per frame

}
