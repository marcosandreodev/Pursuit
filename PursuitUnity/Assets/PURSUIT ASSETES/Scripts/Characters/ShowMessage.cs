using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour
{

    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        Object.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider other)
    {
        Object.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Object.SetActive(false);
    }


}
