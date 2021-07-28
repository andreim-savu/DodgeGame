using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public List<Block> blocks = new List<Block>();

    int state = 0;

    private void Start()
    {
        GameController.i.levelStarted = true;
    }

    List<int> blocksToTrigger = new List<int>();

    private void Update()
    {
        switch (state)
        {
            case 0:
                if (GameController.i.timer > 3.0f)
                {
                    blocks[4].SetAction("damage", 4.0f);
                    state = 1;
                }
                break;
            case 1:
                if (GameController.i.timer > 8.5f)
                {
                    blocksToTrigger = new List<int> { 1, 3, 5, 7 };
                    foreach (int i in blocksToTrigger)
                    {
                        blocks[i].SetAction("damage", 4.0f);
                    }
                    state = 2;
                }
                break;
            case 2:
                if (GameController.i.timer > 13.5f)
                {
                    blocksToTrigger = new List<int> { 0, 2, 4, 6, 8 };
                    foreach (int i in blocksToTrigger)
                    {
                        blocks[i].SetAction("damage", 4.0f);
                    }
                    state = 3;
                }
                break;
            case 3:
                if (GameController.i.timer > 18.5f)
                {
                    blocksToTrigger = new List<int> { 0, 1, 2, 3, 5, 6, 7, 8 };
                    foreach (int i in blocksToTrigger)
                    {
                        blocks[i].SetAction("damage", 3.0f);
                    }
                    blocks[4].SetAction("attack", 3.0f);
                    state = 4;
                }
                break;
            case 4:
                if (GameController.i.timer > 22.0f)
                {
                    blocksToTrigger = new List<int> { 3, 4, 5 };
                    foreach (int i in blocksToTrigger)
                    {
                        blocks[i].SetAction("damage", 3.0f);
                    }
                    state = 5;
                }
                break;
            case 5:
                if (GameController.i.timer > 23.5f)
                {
                    blocksToTrigger = new List<int> { 1, 7 };
                    foreach (int i in blocksToTrigger)
                    {
                        blocks[i].SetAction("damage", 3.0f);
                    }
                    state = 6;
                }
                break;
        }
    }
}
