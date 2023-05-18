using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class BlinkLight : MonoBehaviour
{
    public Light2D spotLight;
    public float timer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        spotLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (GetComponent<Light2D>().enabled == true)
            {
                GetComponent<Light2D>().enabled = false;
            }
            else if (GetComponent<Light2D>().enabled == false)
            {
                Debug.Log("I'm flashing you.");
                GetComponent<Light2D>().enabled = true;
            }
            timer = 0.5f;
        }
    }
}
