using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    private NavMeshAgent agent;
    private Vector3 destinoActual;

    List<Vector3>  listadoPuntos = new List<Vector3>();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
        //va recorriendo todos los puntos q tiene mi ruta
        foreach (Transform punto in ruta)
        {
            listadoPuntos.Add(punto.position);
        }
        CalcularDestino();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());   
    }
    private IEnumerator PatrullarYEsperar()
    {
        agent.SetDestination(destinoActual);
        yield return null;
    }
    private void CalcularDestino()
    {
        destinoActual = listadoPuntos[0];
    }
}
