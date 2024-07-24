using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class draw_manager : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Line line;
    private Line current_line;
    Vector3 SpawnPos;
    float distance;
    Plane Ground = new Plane(Vector3.up, 0);
    public const float resolution = 1f;
    MeshCollider meshCollider;

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
//        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Ground.Raycast(ray, out distance))
            {
                SpawnPos = ray.GetPoint(distance);
            }
            current_line = Instantiate(line, SpawnPos, transform.rotation);
        }

        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Ground.Raycast(ray, out distance))
            {
                SpawnPos = ray.GetPoint(distance);
            }
            current_line.SetPosition(SpawnPos);


            //meshCollider = line.AddComponent<MeshCollider>();
            //Mesh mesh = new Mesh();
            
            //meshCollider.sharedMesh = mesh;

            //current_line = Instantiate(line, SpawnPos, transform.rotation);
        }
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //line.AddComponent<MeshCollider>();
        }
    }
}
