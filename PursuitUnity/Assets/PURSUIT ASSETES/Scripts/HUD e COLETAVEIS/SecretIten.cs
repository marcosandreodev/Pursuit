using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretIten : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string id;
    public GameObject CanvaItem;
    public GameObject CanvaE;
    public float displayTime = 2f;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public int value;
    bool isTrigger;
    bool collected = false;

    private void Update()
    {
        if (isTrigger && !collected)
        {
            CanvaE.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                collected = true;
                CounterItem.instance.IncreasePoint(value);
                CanvaE.SetActive(false);
                StartCoroutine(DisplayCanvas());
                // Desligar a hitbox do trigger
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }

    public void LoadData(GameData data)
    {
        data.itensCollected.TryGetValue(id, out collected);
        if (collected)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.itensCollected.ContainsKey(id))
        {
            data.itensCollected.Remove(id);
        }
        data.itensCollected.Add(id, collected);
    }

    private IEnumerator DisplayCanvas()
    {
        CanvaItem.SetActive(true); // Ativa o objeto Canvas

        yield return new WaitForSeconds(displayTime); // Aguarda o tempo determinado

        CanvaItem.SetActive(false); // Desativa o objeto Canvas
    }
}