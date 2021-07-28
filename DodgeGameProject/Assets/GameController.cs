using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController i;

    public int score;
    public Text scoreText;

    public bool playerAlive = true;

    private void Awake()
    {
        if (!i) { i = this; }
        else { Destroy(this); }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
}
