using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{

    private Animator animator;
    private string currentAnimation;

    public GameObject doorHitBox;
    public GameObject doorHitBox2;
    public bool isTrigger;
    public bool showSecondPart;


    const string OPEN = "Aberta";
    const string CLOSE = "Fechada";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
      if (isTrigger && Input.GetKeyDown(KeyCode.E))
        {
            doorHitBox.SetActive(false);
            ChangeAnimationState(OPEN);
            showSecondPart = true;
        }   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;   

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChangeAnimationState(CLOSE);
            doorHitBox.SetActive(true);
            //doorHitBox2.SetActive(true);
        }
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
