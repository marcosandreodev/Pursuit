using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckManager : MonoBehaviour
{
    // Variáveis para armazenar a posição do último checkpoint alcançado e se um checkpoint foi alcançado
    private static Vector2 checkpointPosition = Vector2.zero;
    private static bool checkpointReached = false;





    // Método para salvar a posição do checkpoint
    public static void SaveCheckpoint(Vector2 position)
    {
        checkpointPosition = position;
        checkpointReached = true;
    }

    // Método para verificar se um checkpoint foi alcançado
    public static bool HasCheckpoint()
    {
        return checkpointReached;
    }

    // Método para carregar a cena atual e posicionar o jogador no último checkpoint alcançado
    public static void LoadCheckpoint()
    {
        if (checkpointReached)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.transform.position = checkpointPosition;
        }
    }

    // Método para limpar o checkpoint atual
    public static void ClearCheckpoint()
    {
        checkpointReached = false;
    }

    // Método para ir para o menu principal
    public void GoToMainMenu()
    {
        // Salva um checkpoint vazio na posição (0, 0)
        SaveCheckpoint(Vector2.zero);
        // Salva a posição do último checkpoint alcançado nos PlayerPrefs
        PlayerPrefs.SetFloat("CheckpointX", checkpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointY", checkpointPosition.y);
        // Carrega a cena do menu principal
        SceneManager.LoadScene("MenuOficial");
    }

    // Método para continuar a partir do último checkpoint alcançado
    public void Continue()
    {
        // Obtém a posição do último checkpoint alcançado dos PlayerPrefs
        float checkpointX = PlayerPrefs.GetFloat("CheckpointX");
        float checkpointY = PlayerPrefs.GetFloat("CheckpointY");
        // Salva a posição do último checkpoint alcançado
        SaveCheckpoint(new Vector2(checkpointX, checkpointY));
        // Carrega a cena atual e posiciona o jogador no último checkpoint alcançado
        LoadCheckpoint();
    }
}
