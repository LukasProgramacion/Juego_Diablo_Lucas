using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu (menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial;
    public string ordenFinal;

    public bool repetible;
    public int repeticionesTotales;
    public int estadoActual;

    public int indiceMision;
}
