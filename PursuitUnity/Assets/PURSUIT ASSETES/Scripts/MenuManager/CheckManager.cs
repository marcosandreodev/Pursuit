using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckManager : MonoBehaviour
{
    // Vari�veis para armazenar a posi��o do �ltimo checkpoint alcan�ado e se um checkpoint foi alcan�ado
    private static Vector2 checkpointPosition = Vector2.zero;
    private static bool checkpointReached = false;





    // M�todo para salvar a posi��o do checkpoint
    public static void SaveCheckpoint(Vector2 position)
    {
        checkpointPosition = position;
        checkpointReached = true;
    }

    // M�todo para verificar se um checkpoint foi alcan�ado
    public static bool HasCheckpoint()
    {
        return checkpointReached;
    }

    // M�todo para carregar a cena atual e posicionar o jogador no �ltimo checkpoint alcan�ado
    public static void LoadCheckpoint()
    {
        if (checkpointReached)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.transform.position = checkpointPosition;
        }
    }

    // M�todo para limpar o checkpoint atual
    public static void ClearCheckpoint()
    {
        checkpointReached = false;
    }

    // M�todo para ir para o menu principal
    public void GoToMainMenu()
    {
        // Salva um checkpoint vazio na posi��o (0, 0)
        SaveCheckpoint(Vector2.zero);
        // Salva a posi��o do �ltimo checkpoint alcan�ado nos PlayerPrefs
        PlayerPrefs.SetFloat("CheckpointX", checkpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointY", checkpointPosition.y);
        // Carrega a cena do menu principal
        SceneManager.LoadScene("MenuOficial");
    }

    // M�todo para continuar a partir do �ltimo checkpoint alcan�ado
    public void Continue()
    {
        // Obt�m a posi��o do �ltimo checkpoint alcan�ado dos PlayerPrefs
        float checkpointX = PlayerPrefs.GetFloat("CheckpointX");
        float checkpointY = PlayerPrefs.GetFloat("CheckpointY");
        // Salva a posi��o do �ltimo checkpoint alcan�ado
        SaveCheckpoint(new Vector2(checkpointX, checkpointY));
        // Carrega a cena atual e posiciona o jogador no �ltimo checkpoint alcan�ado
        LoadCheckpoint();
    }
}
