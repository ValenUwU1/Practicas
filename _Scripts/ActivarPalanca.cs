using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPalanca : Palanca
{
    //Apretar E para activar la palanca
    public void Activar()
    {
        Debug.Log("+2");
        Interaccion();
    }
}
