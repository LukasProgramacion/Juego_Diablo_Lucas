using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour, IInteratcuable
{
    [SerializeField]
    private EventManagerSO eventManager;

    [SerializeField]
    private MisionSO misionAsociada;

    [SerializeField]
    private DialogoSO dialogo1;

    [SerializeField]
    private DialogoSO dialogo2;
    
    private Outline outline;

    [SerializeField] private DialogoSO dialogo;

    [SerializeField] private float tiempoRotacion;

    [SerializeField] private Transform cameraPoint;

    private DialogoSO dialogoActual;
    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
        dialogoActual = dialogo1;
    }

    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(misionTerminada == misionAsociada)
        {
            dialogoActual = dialogo2;
            
        }
        
    }

    public void Interactuar (Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(()=> SistemaDialogos.sistema.IniciarDialogo(dialogoActual, cameraPoint));
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
