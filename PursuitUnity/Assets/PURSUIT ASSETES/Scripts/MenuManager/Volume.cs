using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioSource Musicafundo;


    public void VolumeMusica(float value)
    {
        Musicafundo.volume = value;
    }
}
