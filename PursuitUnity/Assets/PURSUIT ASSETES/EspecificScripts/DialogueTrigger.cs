using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DialogueTrigger : MonoBehaviour
{ 
    public static DialogueTrigger instance;

    public Dialogue dialogue;
    public GameObject trigger;
    public GameObject loadScene;
    bool isTrigger;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void FixedUpdate()
    {
        if (isTrigger) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            trigger.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;
        }
    }
}
