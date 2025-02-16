using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



[CreateAssetMenu(menuName = "Event manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action<MisionSO> OnNuevaMision;
    public event Action<MisionSO> OnActualizarMision;
    public event Action<MisionSO> OnTerminarMision;
  
    internal void NuevaMision(MisionSO mision)
    {
        //comprobar si hay suscriptores y si hay lanza la mision
        OnNuevaMision?.Invoke(mision);
    }

    public void ActualizarMision(MisionSO mision)
    {
        OnActualizarMision?.Invoke(mision);
    }

    public void TerminarMision (MisionSO mision)
    {
        OnTerminarMision?.Invoke(mision);
        FinalDelJuego();
    }

    /*public void FinalDelJuego()
    {
        SceneManager.LoadScene(2);
    }
    */
}
