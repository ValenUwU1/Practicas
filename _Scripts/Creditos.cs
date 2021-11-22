using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Cargar.CargarEscena(Cargar.escenas.Menu);
        }
    }
}
