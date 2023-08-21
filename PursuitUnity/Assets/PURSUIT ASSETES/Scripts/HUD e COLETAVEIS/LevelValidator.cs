using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelValidator : MonoBehaviour
{
    int level;
    [SerializeField] private GameData data;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Validate(data);
        Debug.Log("LEVEL: " + level);
    }

    public void Validate(GameData data)
    {
        level = data.level;
    }
}
