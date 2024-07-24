using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn_Enemy3 : MonoBehaviour
{

    private List<GameObject> enemies = new List<GameObject>();

    public GameObject enemy;
    public GameObject enemy2;
    public int xPos1;
    public int yPos1;
    public int xPos;
    public int ypos;
    public int count;
    float timer = 0f;
    int left = 0;

    public int level = 1;

    void Start()
    {
        StartCoroutine(Spawn_Enemy());
    }

    public void Increasing()
    {
        level++;
    }

    IEnumerator Spawn_Enemy()
    {
        while (count < 30)
        {
            timer = 5;
            int rand = Random.Range(0, 3);
            if (rand == 0) xPos = -42;
            else if (rand == 1) xPos = 50;
            else if (rand == 2) ypos = -38;
            if (rand != 2)
            {
                ypos = Random.Range(-39, -28);
                if (ypos > -3 && ypos < 10)
                {
                    ypos += 13;
                }
            }
            else
            {
                xPos = Random.Range(34, -37);
                if (xPos > -12 && xPos < 8)
                {
                    xPos += 20;
                }
            }
            rand = Random.Range(0, 2);
            if (rand == 0)
            {
                Instantiate(enemy, new Vector3(xPos, 1, ypos), Quaternion.identity);
            }
            else
            {
                Instantiate(enemy2, new Vector3(xPos, 1, ypos), Quaternion.identity);
            }

            timer = Random.Range(4, 6);

            yield return new WaitForSeconds(timer);
            count += 1;
        }
    }
}

