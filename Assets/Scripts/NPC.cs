using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour, IInteratcuable
{
    private Outline outline;

    [SerializeField] private DialogoSO dialogo;

    [SerializeField] private float tiempoRotacion;

    [SerializeField] private Transform cameraPoint;
    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void Interactuar (Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(()=> SistemaDialogos.sistema.IniciarDialogo(dialogo, cameraPoint));
        //SistemaDialogos.sistema.IniciarDialogo();
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
