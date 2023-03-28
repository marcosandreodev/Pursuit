using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string NomeLevel;
    [SerializeField] private GameObject PainelMenuI;
    [SerializeField] private GameObject PainelO;
   public void Jogar()
    {
        SceneManager.LoadScene(NomeLevel);
    }
    public void AbrirOp()
    {
        PainelMenuI.SetActive(false);
        PainelO.SetActive(true);
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
}
