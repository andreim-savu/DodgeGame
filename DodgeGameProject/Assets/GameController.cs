using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController i;

    public float timer;
    public Text timeText;

    public bool playerAlive = true;

    public bool levelStarted;

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
        if (levelStarted)
        {
            timer += Time.deltaTime;
            timeText.text = "Time: " + timer.ToString("F2");
        }
    }
}
