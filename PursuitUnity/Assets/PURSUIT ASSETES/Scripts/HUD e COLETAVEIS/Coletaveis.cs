using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    bool isCollected = false;
    public GameObject collectabel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            isCollected = true;
            CollectItem();
        }
    }

    public void CollectItem()
    {
        Destroy(collectabel);
    }
}
