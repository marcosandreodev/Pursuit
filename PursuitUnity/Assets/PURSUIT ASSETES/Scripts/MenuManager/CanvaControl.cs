using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CanvaControl : MonoBehaviour
{
    [SerializeField] private GameObject Canva1;
    [SerializeField] private GameObject Canva2;
    [SerializeField] private string NomeLevel;


    public void Seta()
    {
        Canva1.SetActive(false);
        Canva2.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(NomeLevel);
    }
}