using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carga : MonoBehaviour
{
    //Llamar a la pantalla de carga 1 vez
    private bool n = true;
    private void Update()
    {
        if (n == true)
        {
            n = false;
            Cargar.Carga();
        }
    }
}
