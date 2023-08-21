using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challange : MonoBehaviour
{
    // Start is called before the first frame update
    public MenuManager menuManager;
    public Enemy enemy;

    public int dificuldade = 1;

    void Start()
    {

        SetChallenge();
    }

    public void SetChallenge()
    {
        dificuldade = 1;
    }
}
