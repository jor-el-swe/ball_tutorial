using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TraceMovement : MonoBehaviour
{
    public float speed = 10;
    public float time = 0.5f;
    private Rigidbody rb;
    
    bool running;
    List<Vector3> movements =new List<Vector3>();
    private bool completed;

    private Vector3 cameraPosition;
    public Vector3 ro;
    private bool startedTracing;

    void Start()
    {
       // rb = GetComponent<Rigidbody>();
        ro= new Vector3(0,0,0);
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag != "Ground")
                    return;
                
                var newPosition = new Vector3(hit.point.x, 0.5f, hit.point.z);
                if (movements.Count > 0)
                { 
                    if(Vector3.Distance(movements[movements.Count - 1], newPosition) > 0.5f)
                        movements.Add(newPosition);
                }
                else 
                {
                    movements.Add(newPosition); 
                }
            }
        }
        else
        {
            if (movements.Count > 0 && !startedTracing)
            {
                Debug.Log("points: " + movements.Count);
                startedTracing = true;
                StartCoroutine(TraceBall());
            }
        }

        IEnumerator TraceBall()
        {
            foreach (var point in movements)
            {
                while (Vector3.Distance(transform.position, point) > 0.05f)
                {
                    transform.position = Vector3.Lerp(transform.position, point, 0.1f);
                    yield return new WaitForSeconds(0.0001f);
                }
            }
            movements.Clear();
            startedTracing = false;
            yield break;
        }
        
    }
}
