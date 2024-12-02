using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcultaParedes : MonoBehaviour
{
    [SerializeField] Renderer[] paredes;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            foreach (var pared in paredes)
            {
                pared.enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var pared in paredes)
            {
                pared.enabled = true;
            }
        }
    }
}
