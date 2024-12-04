using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float distanciaInteraccion;
    
    private Camera cam;
    
    private NavMeshAgent agent;

    private NPC npcActual;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        if(npcActual)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npcActual.Interactuar(this.transform);
                npcActual = null;
                agent.isStopped = true;
                agent.stoppingDistance = 0;
            }
        }
        
        
    }

    private void Movimiento()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Mirar a ver si el punto donde he impactado tiene el script "NPC"
                if (hit.transform.TryGetComponent(out NPC npc))
                {
                    //y en ese caso, ese npc es el actual.
                    npcActual = npc;
                    //ahora mi distancia de parada es la de inerccion (a x metros del npc)
                    agent.stoppingDistance = distanciaInteraccion;
                }

                agent.SetDestination(hit.point);
            }
        }
    }
}
