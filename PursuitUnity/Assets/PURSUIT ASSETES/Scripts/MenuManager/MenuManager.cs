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
    [SerializeField] private string NomeCheck;

    private int dificuldade;
    public Image legenda;

    public void NovoJogo()
    {
        PlayerPrefs.DeleteAll();
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
        OnApplicationQuit();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    public void Continuar()
    {

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
            case 1: legenda.sprite = Resources.Load<Sprite>("MenuOficial/facil"); break;
            case 2: legenda.sprite = Resources.Load<Sprite>("MenuOficial/medio"); break;
            case 3: legenda.sprite = Resources.Load<Sprite>("MenuOficial/dificil"); break;
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
