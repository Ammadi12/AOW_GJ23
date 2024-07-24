using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn_Enemy5 : MonoBehaviour
{

    private List<GameObject> enemies = new List<GameObject>();

    public GameObject enemy;
    public GameObject enemy2;
    private int xPos;
    private int ypos;
    private int ypos1;
    private int xpos1;
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
            left = Random.Range(0, 2);
            int rand = Random.Range (0, 2);
            if (rand == 0) ypos1 = -38;
            else if (rand == 1) ypos1 = 40;

            if (left == 0) xPos = -46;            
            else if (left == 1) xPos = 55;

            ypos = Random.Range(-30, 40);
            xpos1 = Random.Range(-39, 39);

            if (xpos1 > -12 && xpos1 < 8)
            {
                xpos1 += 20;
            }

            if (ypos > -3 && ypos < 10)
            {
                ypos += 13;
            }
            Instantiate(enemy, new Vector3(xPos, 1, ypos), Quaternion.identity);
            Instantiate(enemy2, new Vector3(xpos1, 1, ypos1), Quaternion.identity);

            timer = Random.Range(3, 6);

            yield return new WaitForSeconds(timer);
            count += 1;
        }
    }
}

