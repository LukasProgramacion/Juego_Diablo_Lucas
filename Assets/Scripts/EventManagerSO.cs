using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Event manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action OnNuevaMision;
    internal void NuevaMision()
    {
       OnNuevaMision.Invoke();
    }
}
