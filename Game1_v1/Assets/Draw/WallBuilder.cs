using UnityEngine;
using System.Collections.Generic;

namespace Shady
{
    public class WallBuilder : MonoBehaviour
    {
        [SerializeField] Camera Cam = null;
        [SerializeField] GameObject linePrefab = null;
        [SerializeField] GameObject wallPrefab = null;

        private List<GameObject> lines = new List<GameObject>();
        private List<Vector3> currentLinePoints = new List<Vector3>();
        float timer = 0f;
        float anothertimer = 0f;

        void Start()
        {
            if (!Cam)
            {
                Cam = Camera.main;
            }
        }
        
        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    CreateNewLine();
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    UpdateLine(touch.position); 
                }
            }

            if (timer <= 8)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                timer = 0;
                ClearLines();
            }
        }

        private void CreateNewLine()
        {
            currentLinePoints = new List<Vector3>();
            GameObject newLine = Instantiate(linePrefab);
            newLine.transform.SetParent(transform, true);
            lines.Add(newLine);
        }

        private void UpdateLine(Vector2 touchPosition)
        {
            Ray ray = Cam.ScreenPointToRay(touchPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Writable"))
                {
                    currentLinePoints.Add(hit.point);
                    UpdateMeshRenderer();
                }
            }
        }

        private void UpdateMeshRenderer()
        {
            if (lines.Count > 0 && currentLinePoints.Count > 1)
            {
                foreach (GameObject line in lines)
                {
                    MeshRenderer meshRenderer = line.GetComponent<MeshRenderer>();
                    MeshFilter meshFilter = line.GetComponent<MeshFilter>();

                    Mesh mesh = new Mesh();
                    Vector3[] vertices = currentLinePoints.ToArray();
                    int[] triangles = CreateTriangles((int)((int)(float)currentLinePoints.Count * Time.deltaTime));
                    mesh.vertices = vertices;
                    mesh.triangles = triangles;
                    mesh.RecalculateNormals();

                    meshFilter.mesh = mesh;

                    // Instantiate walls along the line
                    CreateWallsAlongLine(line, currentLinePoints);
                }
            }
        }

        private int[] CreateTriangles(int vertexCount)
        {
            List<int> triangles = new List<int>();
            for (int i = 1; i < vertexCount - 1; i++)
            {
                triangles.Add(0);
                triangles.Add(i);
                triangles.Add(i + 1);
            }
            return triangles.ToArray();
        }

        private void CreateWallsAlongLine(GameObject line, List<Vector3> points)
        {
            for (int i = 1; i < points.Count; i++)
            {
                Vector3 midpoint = (points[i - 1] + points[i]) / 2f;
                Vector3 direction = points[i] - points[i - 1];
                float distance = direction.magnitude;

                GameObject newWall = Instantiate(wallPrefab, midpoint, Quaternion.LookRotation(direction));
                newWall.transform.SetParent(line.transform);
                newWall.transform.localScale = new Vector3(1f, 1f, distance);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Touche anything");
            if (gameObject.tag == "Walls")
            {
                Debug.Log("Touche walls");
            }
            else if (gameObject.tag == "Wall2")
            {
                Debug.Log("Touche Wall2");
            }
        }

        public void test()
        {
            Debug.Log("Test function reached");
        }

        public void ClearLines()
        {
            foreach (GameObject line in lines)
            {
                Destroy(line);
            }
            lines.Clear();
            currentLinePoints.Clear();
        }
    }
}
