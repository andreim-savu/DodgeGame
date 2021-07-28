using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health = 3;

    public Text healthText;

    void Start()
    {
        healthText.text = "HP: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health = Mathf.Max(health - amount, 0);
        healthText.text = "HP: " + health.ToString();

        if (health == 0)
        {
            GameController.i.playerAlive = false;
            Destroy(gameObject);
        }
    }
}
