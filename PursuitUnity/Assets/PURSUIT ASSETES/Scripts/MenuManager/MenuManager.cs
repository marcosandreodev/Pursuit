using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string NomeLevel;
    [SerializeField] private GameObject PainelMenuI;
    [SerializeField] private GameObject PainelO;

    private int dificuldade;
    public Image legenda;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeLevel);
    }
    public void AbrirOp()
    {
        PainelMenuI.SetActive(false);
        PainelO.SetActive(true);
        GetDificuldade();
        Setlegenda();
    }
    public void FechaOp()
    {
        PainelO.SetActive(false);
        PainelMenuI.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }

    void GetDificuldade()
    {
        if (PlayerPrefs.HasKey("Dificuldade"))
        {
            dificuldade = PlayerPrefs.GetInt("Dificuldade");
        }
        else
        {
            dificuldade = 2;
        }
       
    }

    void Setlegenda()
    {
        switch (dificuldade)
        {
            case 1: legenda.sprite = Resources.Load<Sprite>("Menu/Facil"); break;
            case 2: legenda.sprite = Resources.Load<Sprite>("Menu/medio"); break;
            case 3: legenda.sprite = Resources.Load<Sprite>("Menu/dificil"); break;
        }
    }

    public void SetEasy()
    {
        GetDificuldade();

        dificuldade--;
        if (dificuldade < 1) dificuldade = 1;

        SetDificuldade();
    }

    public void SetHard()
    {
        GetDificuldade();

        dificuldade++;
        if (dificuldade > 3) dificuldade = 3;

        SetDificuldade();
    }

    public void SetDificuldade()
    {
        PlayerPrefs.SetInt("Dificuldade", dificuldade);
        Setlegenda();
    }
}
