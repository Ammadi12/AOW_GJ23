using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPosition (Vector3 position)
    {
        if (!CanAppend(position)) return;

        renderer.positionCount++;
        renderer.SetPosition(renderer.positionCount - 1, position);
        //gameObject.AddComponent<MeshCollider>();
    }
    private bool CanAppend (Vector3 position)
    {
        if(renderer.positionCount == 0) { return true; }
        return Vector3.Distance(renderer.GetPosition(renderer.positionCount - 1), position) > draw_manager.resolution;
    }
}
