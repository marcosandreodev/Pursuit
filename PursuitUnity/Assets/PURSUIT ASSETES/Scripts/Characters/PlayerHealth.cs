using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float health;
    public float maxHealth;
    public Image healthBar;
    public bool playerIsDead; 
    public GameManagerScript gameManager;

    void Start()
    {
        maxHealth= health; 
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health/maxHealth,0, 100);
        if (health <= 0 && !playerIsDead)
        {
            playerIsDead= true;
            gameManager.gameOver();
           gameObject.SetActive(false);
        }
    }
}
