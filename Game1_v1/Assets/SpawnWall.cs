using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Wall;
    Plane Ground = new Plane (Vector3.up, 0);
    float distance;
    Vector3 SpawnPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
            
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Ground.Raycast(ray, out distance))
            {
                SpawnPos = ray.GetPoint(distance);
            }
            Instantiate(Wall, SpawnPos,transform.rotation);
            
        }
    }
}
