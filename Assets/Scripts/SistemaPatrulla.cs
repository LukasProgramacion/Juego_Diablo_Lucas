using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    [SerializeField] private NavMeshAgent agent;
    private Vector3 destinoActual;
    private int indiceRutaActual = -1;
    private float tiempoEntrePuntos;

    List<Vector3> listadoPuntos = new List<Vector3>();
        
    private void Awake()
    {
        
        //va recorriendo todos los puntos q tiene mi ruta
        foreach (Transform punto in ruta)
        {
            listadoPuntos.Add(punto.position);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }
    private IEnumerator PatrullarYEsperar()
    {
        while (true)
        {
            CalcularDestino();
            agent.SetDestination(destinoActual);
            //esperas a llegar al destino y repites
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= 0.2f);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
        
        
    }
    private void CalcularDestino()
    {
        indiceRutaActual++;

        if(indiceRutaActual >= listadoPuntos.Count)
        {
            indiceRutaActual = 0;
        }

        destinoActual = listadoPuntos[indiceRutaActual];
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
