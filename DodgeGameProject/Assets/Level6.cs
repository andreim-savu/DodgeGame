using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6 : MonoBehaviour
{
    public List<Block> blocks = new List<Block>();

    List<List<int>> columns = new List<List<int>>();
    List<int> c0 = new List<int> { 0, 9, 18, 27, 36 };
    List<int> c1 = new List<int> { 1, 10, 19, 28, 37 };
    List<int> c2 = new List<int> { 2, 11, 20, 29, 38 };
    List<int> c3 = new List<int> { 3, 12, 21, 30, 39 };
    List<int> c4 = new List<int> { 4, 13, 22, 31, 40 };
    List<int> c5 = new List<int> { 5, 14, 23, 32, 41 };
    List<int> c6 = new List<int> { 6, 15, 24, 33, 42 };
    List<int> c7 = new List<int> { 7, 16, 25, 34, 43 };
    List<int> c8 = new List<int> { 8, 17, 26, 35, 44 };

    List<List<int>> rows = new List<List<int>>();
    List<int> r0 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    List<int> r1 = new List<int> { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
    List<int> r2 = new List<int> { 18, 19, 20, 21, 22, 23, 24, 25, 26 };
    List<int> r3 = new List<int> { 27, 28, 29, 30, 31, 32, 33, 34, 35 };
    List<int> r4 = new List<int> { 36, 37, 38, 39, 40, 41, 42, 43, 44 };

    void Start()
    {
        columns.Add(c0);
        columns.Add(c1);
        columns.Add(c2);
        columns.Add(c3);
        columns.Add(c4);
        columns.Add(c5);
        columns.Add(c6);
        columns.Add(c7);
        columns.Add(c8);

        rows.Add(r0);
        rows.Add(r1);
        rows.Add(r2);
        rows.Add(r3);
        rows.Add(r4);

        StartCoroutine(FollowAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawInAttack(bool right)
    {
        if (right)
        {

        }
    }

    IEnumerator DrawInAttackRoutine(bool right)
    {
        yield return new WaitForSeconds(2);
        if (right)
        {
            foreach (int i in columns[0]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[1]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[2]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[3]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[4]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[5]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[6]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[7]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[8]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(1.7f);
            foreach (int i in columns[1]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[2]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[3]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[4]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[5]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[6]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[7]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[8]) { blocks[i].SetAction("damage", 2.0f); }
        }
        else
        {
            foreach (int i in columns[8]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[7]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[6]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[5]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[4]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[3]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[2]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[1]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(0.5f);
            foreach (int i in columns[0]) { blocks[i].SetAction("damage", 1.5f); }
            yield return new WaitForSeconds(1.7f);
            foreach (int i in columns[0]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[1]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[2]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[3]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[4]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[5]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[6]) { blocks[i].SetAction("damage", 2.0f); }
            foreach (int i in columns[7]) { blocks[i].SetAction("damage", 2.0f); }
        }
    }

    void CheckerAttack()
    {
        List<List<int>> tempCol = new List<List<int>>(columns);
        List<List<int>> tempRow = new List<List<int>>(rows);

        for (int i = 0; i < 3; i++) { tempCol.RemoveAt(Random.Range(0, tempCol.Count)); }
        for (int i = 0; i < 2; i++) { tempRow.RemoveAt(Random.Range(0, tempRow.Count)); }

        foreach (List<int> list in tempCol)
        {
            foreach (int i in list) { blocks[i].SetAction("damage", 2.5f); }
        }
        foreach (List<int> list in tempRow)
        {
            foreach (int i in list) { blocks[i].SetAction("damage", 2.5f); }
        }
    }

    IEnumerator FollowAttack()
    {
        yield return new WaitForSeconds(2.5f);
        PlayerStats.i.currentBlock.SetAction("pushdamage", 3.0f, "left");
        /*for (int i = 0; i < 150; i++)
        {
            PlayerStats.i.currentBlock.SetAction("damage", 1.0f);
            yield return new WaitForSeconds(0.1f);
        }*/
    }
}
