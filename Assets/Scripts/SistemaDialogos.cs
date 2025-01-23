using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogos : MonoBehaviour
{
    [SerializeField]
    private EventManagerSO eventManager;
    
    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;

    private bool escribiendo;
    private int indiceFraseActual;

    private DialogoSO dialogoActual;

    [SerializeField] private Transform npcCamera;

    public static SistemaDialogos sistema;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
    private void Awake()
    {
        //si el trono esta vacio...
        if(sistema == null)
        {
            //reclamo el trono y soy yo
            sistema = this;

            //y no me destruyo entre escenas. 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void IniciarDialogo(DialogoSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0f;

        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);

        dialogoActual = dialogo;
        marcos.SetActive(true);

        StartCoroutine(EscribirFrase());
    }

    //Texto aparece letra por letra
    private IEnumerator EscribirFrase()
    {
        escribiendo = true;
        
        textoDialogo.text = "";
        
        char[] frasEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in frasEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }

        escribiendo = false;
    }

    public void SiguienteFrase()
    {
        if(escribiendo)
        {
            CompletarFrase();
        }
        else
        {
            indiceFraseActual++;
            if(indiceFraseActual < dialogoActual.frases.Length)
            {
                StartCoroutine(EscribirFrase());
            }
            else
            {
                TerminarDialogo();
            }
        }
    }

    private void CompletarFrase()
    {
        StopAllCoroutines();
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        escribiendo = false;
    }

    private void TerminarDialogo()
    {
        marcos.SetActive(false);
        StopAllCoroutines();
        indiceFraseActual = 0;
        escribiendo = false;
        dialogoActual = null;
        Time.timeScale = 1;

        if(dialogoActual.tieneMision)
        {
            eventManager.NuevaMision();
        }
    }
}
