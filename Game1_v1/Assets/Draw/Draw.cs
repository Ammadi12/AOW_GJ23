//Shady
using UnityEngine;
using System.Collections.Generic;

namespace Shady
{
    public class Draw : MonoBehaviour
    {
        [SerializeField] LineRenderer trailPrefab = null;

        private LineRenderer currentTrail;
        private List<Vector3> points = new List<Vector3>();

        void Start()
        {
           
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    CreateNewLine();
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    AddPoint(touch.position);
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (transform.childCount != 0)
                {
                    foreach (Transform R in transform)
                    {
                        Destroy(R.gameObject);
                    }
                }
            }
        }

        private void CreateNewLine()
        {
            currentTrail = Instantiate(trailPrefab);
            currentTrail.transform.SetParent(transform, true);
            points.Clear();
        }

        private void UpdateLinePoints()
        {
            if (currentTrail != null && points.Count > 1)
            {
                currentTrail.positionCount = points.Count;
                currentTrail.SetPositions(points.ToArray());
            }
        }

        private void AddPoint(Vector2 touchPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Writable"))
                {
                    points.Add(hit.point);
                    UpdateLinePoints();
                }
            }
        }

     
    }
}