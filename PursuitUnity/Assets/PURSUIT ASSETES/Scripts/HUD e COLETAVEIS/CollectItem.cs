using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id= System.Guid.NewGuid().ToString();
    }

    public int value;
    bool isTrigger;
    bool collected = false;

    private void Update()
    {
        if (isTrigger && !collected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collected = true;
                CounterItem.instance.IncreasePoint(value);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger=true;
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

}
