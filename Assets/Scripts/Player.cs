using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float tiempoRotacion;


    private Camera cam;
    
    private NavMeshAgent agent;

    private Transform ultimoClick;

    [SerializeField] private Animator anim;
    private PlayerAnimations playerAnimations;

    public PlayerAnimations PlayerAnimations { get => playerAnimations; set => playerAnimations = value; }



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            Movimiento();

        }

        if(ultimoClick && ultimoClick.TryGetComponent(out IInteratcuable interatcuable)) 
        {
            agent.stoppingDistance = distanciaInteraccion;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                LanzarInteraccion(interatcuable);
                
            }
        }
        else if (ultimoClick && ultimoClick.TryGetComponent(out Enemigo enemigo))
        {

        }

        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
        
        
    }

    private void LanzarInteraccion(IInteratcuable interatcuable)
    {
        interatcuable.Interactuar(transform);
         ultimoClick = null;
    }

    private void Movimiento()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                agent.SetDestination(hit.point);
                ultimoClick = hit.transform;
            }
        }
    }

    public void HacerDanho(float danhoAtaque)
    {
       Debug.Log("Me hacen pupa: " + danhoAtaque);
    }
}
