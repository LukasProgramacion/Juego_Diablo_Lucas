using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogos : MonoBehaviour
{
    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;

    private bool escribiendo;
    private int indiceFraseActual;
    
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

    public void IniciarDialogo(DialogoSO dialogo)
    {
        marcos.SetActive(true);
    }

    //Texto aparece letra por letra
    private void EscribirFrase()
    {
        
    }

    private void SiguienteFrase()
    {
        
    }

    private void TerminarDialogo()
    {

    }
}
