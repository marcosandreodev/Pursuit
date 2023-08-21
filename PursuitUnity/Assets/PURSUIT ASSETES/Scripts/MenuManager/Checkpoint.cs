using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector2 checkpointPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointPosition = transform.position;
            CheckManager.SaveCheckpoint(checkpointPosition);
            PlayerPrefs.SetFloat("CheckpointX", checkpointPosition.x);
            PlayerPrefs.SetFloat("CheckpointY", checkpointPosition.y);
            PlayerPrefs.Save();
            Debug.Log("feito");
        }
    }
}
