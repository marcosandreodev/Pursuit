using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOFFONIdle : MonoBehaviour
{
    public GameObject light;

    public void TurnLightOn()
    {
        light.SetActive(true);
    }

    public void TurnLightOff()
    {
        light.SetActive(false);
    }
}
