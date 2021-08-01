using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats i;
    public int health = 3;

    public Text healthText;

    public Block currentBlock;
    public PlayerMovement playerMovement;

    private void Awake()
    {
        if (!i) { i = this; }
        else { Destroy(this); }

        playerMovement = GetComponent<PlayerMovement>();
    }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            if (currentBlock) { currentBlock.OccupyCube(false); }
            currentBlock = other.GetComponent<Block>().OccupyCube(true);
        }
    }
}
