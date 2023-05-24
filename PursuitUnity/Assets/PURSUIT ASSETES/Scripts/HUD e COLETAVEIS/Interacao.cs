using UnityEngine;
using UnityEngine.UI;

public class Interacao : MonoBehaviour
{
    public GameObject PressE; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            PressE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CollectItem()
        }
    }

    private void CollectItem()
    {
        // Implemente a lógica para coletar o item da mesa.
        // Por exemplo, você pode desativar o item, adicionar o item ao inventário do jogador, reproduzir um efeito sonoro, etc.

        Debug.Log("Item collected!");
    }
}