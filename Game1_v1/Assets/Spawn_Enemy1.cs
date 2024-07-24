using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn_Enemy1 : MonoBehaviour
{

    private List<GameObject> enemies = new List<GameObject>();

    public GameObject enemy;
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
        while(count < 20)
        {
            timer = 5;
            left = Random.Range(0, 2);
            if (left == 0)  xPos = -42;
            else if (left == 1) xPos = 50;
            ypos  = Random.Range(-30, 40);
            if (ypos > -3 && ypos < 10)
            {
                ypos += 13; 
            }
            Instantiate(enemy, new Vector3(xPos, 1, ypos), Quaternion.identity);

            timer = Random.Range(3, 6);

            yield return new WaitForSeconds(timer);
            count += 1;
        }
    }
}

