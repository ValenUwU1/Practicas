using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogo
{
    public string nombre;
    [TextArea(1,15)]
    public string[] frases;
    public float[] velocidadtexto;
}
