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

    bool action = false;
    int state = 0;

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

        SetupBlocks();
        StartCoroutine(LevelStartRoutine());
    }

    void Update()
    {
        return;
        if (action) { return; }
        action = true;
        switch (state)
        {
            case 0:
                StartCoroutine(CenterAttackRow());
                state++;
                break;
            case 1:
                StartCoroutine(SideAttackRow());
                state++;
                break;
            case 2:
                StartCoroutine(CheckerAttack());
                state++;
                break;
            case 3:
                StartCoroutine(FollowAttack());
                state++;
                break;
            case 4:
                StartCoroutine(FollowAttackBig());
                state++;
                break;
            case 5:
                StartCoroutine(DrawInAttackRoutine(true));
                state++;
                break;
            case 6:
                StartCoroutine(BeltAttack());
                state++;
                break;
        }
    }

    IEnumerator LevelStartRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].AscendBlock();
            print(i);
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
        }
    }

    void SetupBlocks()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            List<Block> neighbours = new List<Block>();

            int[] neighbourIndexes = new int[8] { i - 10, i - 9, i - 8, i - 1, i + 1, i + 8, i + 9, i + 10 };

            if (i % 9 == 0)
            {
                neighbourIndexes[0] = -1;
                neighbourIndexes[3] = -1;
                neighbourIndexes[5] = -1;
            }

            else if (i % 9 == 8)
            {
                neighbourIndexes[2] = -1;
                neighbourIndexes[4] = -1;
                neighbourIndexes[7] = -1;
            }

            if (i / 9 == 0)
            {
                neighbourIndexes[0] = -1;
                neighbourIndexes[1] = -1;
                neighbourIndexes[2] = -1;
            }

            else if (i / 9 == 4)
            {
                neighbourIndexes[5] = -1;
                neighbourIndexes[6] = -1;
                neighbourIndexes[7] = -1;
            }

            foreach (int index in neighbourIndexes)
            {
                if (index < 0) { continue; }
                neighbours.Add(blocks[index]);
            }

            blocks[i].SetNeighbours(neighbours);
        }
    }

    IEnumerator SideAttackRow()
    {
        foreach (int i in rows[0]) { blocks[i].SetAction("damage", 0.5f); }
        foreach (int i in rows[1]) { blocks[i].SetAction("damage", 0.5f); }
        foreach (int i in rows[3]) { blocks[i].SetAction("damage", 0.5f); }
        foreach (int i in rows[4]) { blocks[i].SetAction("damage", 0.5f); }
        yield return new WaitForSeconds(4.5f);
        action = false;
    }

    IEnumerator CenterAttackRow()
    {
        foreach (int i in rows[1]) { blocks[i].SetAction("damage", 2.5f); }
        foreach (int i in rows[2]) { blocks[i].SetAction("damage", 2.5f); }
        foreach (int i in rows[3]) { blocks[i].SetAction("damage", 2.5f); }
        yield return new WaitForSeconds(4.5f);
        action = false;
    }

    IEnumerator DrawInAttackRoutine(bool right)
    {
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
        yield return new WaitForSeconds(4.5f);
        action = false;
    }

    IEnumerator CheckerAttack()
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
        yield return new WaitForSeconds(4.5f);
        action = false;
    }

    IEnumerator FollowAttack()
    {
        for (int i = 0; i < 150; i++)
        {
            PlayerStats.i.currentBlock.SetAction("damage", 1.0f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(4.5f);
        action = false;
    }

    IEnumerator FollowAttackBig()
    {
        for (int i = 0; i < 15; i++)
        {
            PlayerStats.i.currentBlock.SetAction("damage", 2.5f);
            foreach (Block block in PlayerStats.i.currentBlock.neighbours) { block.SetAction("damage", 2.5f); }
            yield return new WaitForSeconds(1.5f);
        }
        yield return new WaitForSeconds(4.5f);
        action = false;
    }

    IEnumerator BeltAttack()
    {
        List<int> indexes = new List<int> { 0, 1, 2, 3, 4 };
        int safeIndex = Random.Range(0, indexes.Count);
        indexes.RemoveAt(safeIndex);
        yield return new WaitForSeconds(2.5f);
        foreach (int i in columns[0]) { blocks[i].SetAction("damage", 6.5f); }
        yield return new WaitForSeconds(0.5f);
        foreach (int i in columns[1]) { blocks[i].SetAction("damage", 6.0f); }
        yield return new WaitForSeconds(0.5f);
        foreach (int i in columns[2]) { blocks[i].SetAction("damage", 5.5f); }
        yield return new WaitForSeconds(0.5f);
        foreach (int i in columns[3]) { blocks[i].SetAction("damage", 5.0f); }
        yield return new WaitForSeconds(0.5f);
        foreach (int i in columns[4]) { blocks[i].SetAction("damage", 4.5f); }
        yield return new WaitForSeconds(0.5f);
        foreach (int i in columns[5]) { blocks[i].SetAction("damage", 4.0f); }
        yield return new WaitForSeconds(0.5f);
        foreach (int i in columns[6]) { blocks[i].SetAction("damage", 3.5f); }
        yield return new WaitForSeconds(0.5f);
        foreach (int i in columns[7]) { blocks[i].SetAction("damage", 3.0f); }
        yield return new WaitForSeconds(3.0f);
        int count = 0;
        for (int i = 1; i < 9;)
        {
            if (i < 7)
            {
                foreach (int index in columns[7])
                {
                    blocks[index].SetAction("damage", 0.25f);
                }
            }
            if (count == 4)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == safeIndex) { blocks[columns[i][j]].SetAction("push", 11.7f - 1.45f * i, "left"); }
                    else
                    {
                        if (Random.Range(0, 100) < 40)
                        {
                            blocks[columns[i][j]].SetAction("push", 11.7f - 1.45f * i, "left");
                        }
                        else
                        {
                            blocks[columns[i][j]].SetAction("pushdamage", 11.7f - 1.45f * i, "left");
                        }
                    }
                }
                count = -1;
                i++;
            }
            count++;
            yield return new WaitForSeconds(0.25f);
        }
        for (int i = 0; i < columns[0].Count; i++)
        {
            if (i == safeIndex)
            {
                blocks[columns[0][i]].SetAction("attack", 3.0f);
                continue;
            }
            blocks[columns[0][i]].SetAction("damage", 3.0f);
        }
    }

    IEnumerator SectionAttack()
    {
        int[] attackOrder = new int[3] { 0, 1, 2 };
        for (int i = 0; i < 50; i++)
        {
            int i1 = Random.Range(0, 3);
            int i2 = Random.Range(0, 3);
            if (i1 == i2) { continue; }
            int temp = attackOrder[i1];
            attackOrder[i1] = attackOrder[i2];
            attackOrder[i2] = temp;
        }
        foreach (int i in attackOrder)
        {
            if (i == 0)
            {
                foreach (int j in columns[0]) { blocks[j].SetAction("damage", 3.5f); }
                foreach (int j in columns[1]) { blocks[j].SetAction("damage", 3.5f); }
                foreach (int j in columns[2]) { blocks[j].SetAction("damage", 3.5f); }
            }
            if (i == 1)
            {
                foreach (int j in columns[3]) { blocks[j].SetAction("damage", 3.5f); }
                foreach (int j in columns[4]) { blocks[j].SetAction("damage", 3.5f); }
                foreach (int j in columns[5]) { blocks[j].SetAction("damage", 3.5f); }
            }
            if (i == 2)
            {
                foreach (int j in columns[6]) { blocks[j].SetAction("damage", 3.5f); }
                foreach (int j in columns[7]) { blocks[j].SetAction("damage", 3.5f); }
                foreach (int j in columns[8]) { blocks[j].SetAction("damage", 3.5f); }
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}
