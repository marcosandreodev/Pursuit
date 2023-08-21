using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour
{

    public GameObject Object;
    bool isTrigger;
    // Start is called before the first frame update

    public void Update()
    {
        if (isTrigger)
        {
            Object.SetActive(true);
        }
        if (!isTrigger)
        {
            Object.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
    }


}
