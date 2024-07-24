using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 2)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            timer = 0;
            Destroy(gameObject);
        }

    }
}
