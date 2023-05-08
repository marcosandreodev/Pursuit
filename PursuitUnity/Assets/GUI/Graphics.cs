using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphics : MonoBehaviour
{
   
    public static Rect rect(float x, float y, float width, float height)
    {
        return new(Screen.width * (x/100), Screen.height* (y/100), Screen.width * (width/100), Screen.height * (height/100));
    }

    public static float w(float x)
    {
        return Screen.width * x/100;
    }

    public static float h(float y)
    {
        return Screen.width * y / 100;
    }

}
