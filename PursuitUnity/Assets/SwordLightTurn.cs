using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLightTurn : MonoBehaviour
{
    public PlayerWithSword playerWithSword;
    private Animator animator;
    private string currentAnimation;

    const string TURNON = "AnimationLight";
    const string TURNOFF = "NoLight";

    public void Shooting()
    {
        ChangeAnimationState(TURNON); ;
    }

    public void NotShooting()
    {
        ChangeAnimationState(TURNOFF); ;
    }


    void Start()
    {
        animator = GetComponent<Animator>();;
    }

    public void Update()
    {
        if(playerWithSword.isAtacking)
        {
            Shooting();
        }
        if(playerWithSword.isAtacking == false)
        {
            NotShooting();
        }
    }


    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
