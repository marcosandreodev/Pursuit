using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject trigger;
    public GameObject loadScene;


    bool isTrigger;


    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void Update()
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
