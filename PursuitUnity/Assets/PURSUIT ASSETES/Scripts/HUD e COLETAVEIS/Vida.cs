using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerHealth pHealth;
    public float vida;
    [SerializeField] private Transform Spray;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>().health < 100)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                DestroySpray();
                other.gameObject.GetComponent<PlayerHealth>().health += vida;
            }

            else other.gameObject.GetComponent<PlayerHealth>().health = 100;
            {

            }
        } 
    }

    void DestroySpray()
    {
        Destroy(Spray.gameObject);
    }

}
