using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlinkShooy : MonoBehaviour
{
    public GameObject lights;
    public bool lighton = false;
    public float timer = 0.02f;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (!lighton)
            {
                lighton = true;
                lights.SetActive(true);
            }
            else if (lighton)
            {
                lighton = false;
                lights.SetActive(false);
            }
            timer = 0.02f;
        }
    }
}
