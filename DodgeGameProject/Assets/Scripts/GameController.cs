using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController i;

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
}
