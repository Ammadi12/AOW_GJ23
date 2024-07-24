using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn_Enemy4 : MonoBehaviour
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
            int rand = Random.Range(0, 2);
            if (rand == 0) xPos = -20;
            else if (rand == 1) xPos = 51;
            
            ypos = Random.Range(-30, -18);
            if (ypos > -3 && ypos < 10)
            {             
                ypos += 13;
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

            timer = Random.Range(2, 5);

            yield return new WaitForSeconds(timer);
            count += 1;
        }
    }
}

