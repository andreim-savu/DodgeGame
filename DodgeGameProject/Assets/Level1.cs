using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public List<Block> blocks = new List<Block>();

    private void Start()
    {
        StartCoroutine(LevelRoutine());
    }

    IEnumerator LevelRoutine()
    {
        List<int> blocksToTrigger = new List<int>();
        yield return new WaitForSeconds(3);
        /*blocks[4].SetAction("damage", 4.0f);
        yield return new WaitForSeconds(5.5f);
        DiamondAttack(4.0f);
        yield return new WaitForSeconds(5.5f);
        CrossAttack(4.0f);
        yield return new WaitForSeconds(4.5f);
        SquareAttack(3.0f);
        yield return new WaitForSeconds(3.5f);
        RowAttack(1, 2.5f);
        yield return new WaitForSeconds(1.5f);
        ColumnAttack(1, 1.5f);
        yield return new WaitForSeconds(2.0f);*/
        DiamondAttack(3.0f);
        yield return new WaitForSeconds(1.0f);
        SquareAttack(3.0f);
        yield return new WaitForSeconds(1.0f);
        blocks[4].SetAction("damage", 1.5f);
    }

    void DiamondAttack(float timer)
    {
        List<int> blockIndexes = new List<int> { 1, 3, 5, 7 };
        foreach (int i in blockIndexes)
        {
            blocks[i].SetAction("damage", timer);
        }
    }

    void CrossAttack(float timer)
    {
        List<int> blockIndexes = new List<int> { 0, 2, 4, 6, 8 };
        foreach (int i in blockIndexes)
        {
            blocks[i].SetAction("damage", timer);
        }
    }

    void SquareAttack(float timer)
    {
        List<int> blockIndexes = new List<int> { 0, 1, 2, 3, 5, 6, 7, 8 };
        foreach (int i in blockIndexes)
        {
            blocks[i].SetAction("damage", timer);
        }
    }

    void RowAttack(int row, float timer)
    {
        int startIndex = row * 3;
        List<int> blockIndexes = new List<int> { startIndex, startIndex + 1, startIndex + 2 };
        foreach (int i in blockIndexes)
        {
            blocks[i].SetAction("damage", timer);
        }
    }

    void ColumnAttack(int column, float timer) {
        List<int> blockIndexes = new List<int> { column, column + 3, column + 6};
        foreach (int i in blockIndexes)
        {
            blocks[i].SetAction("damage", timer);
        }
    }
}
