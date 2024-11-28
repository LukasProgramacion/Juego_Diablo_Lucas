using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
