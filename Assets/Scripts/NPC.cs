using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Outline outline;

    [SerializeField] private float tiempoRotacion;
    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void Interactuar (Transform interactuador)
    {
        Debug.Log("Hola");
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y);
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;

    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
