using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;

    [SerializeField] float velocidadCombate;
    [SerializeField] float distanciaAtaque;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Animator anim;

    private void Awake()
    {
        main.Combate = this;
        
    }

    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (main.MainTarget != null && agent.CalculatePath(main.MainTarget.position, new NavMeshPath()))
        {
            EnfocarObjetivo();
            agent.SetDestination(main.MainTarget.position);

            if (agent.remainingDistance <= distanciaAtaque)
            {
                anim.SetBool("attacking", true);
            }

        }
        else
        {
            main.ActivarPatrulla();
        }
    }

    private void EnfocarObjetivo()
    {
        Vector3 direccionATarget = (main.MainTarget.position - this.transform.position).normalized;
        direccionATarget.y = 0;
        Quaternion rotacionATarget =  Quaternion.LookRotation(direccionATarget);
        transform.rotation = rotacionATarget;   
    }
}
