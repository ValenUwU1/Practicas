using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKeyDown)
        {
            GameObject[] audio = GameObject.FindGameObjectsWithTag("Audio");
            foreach (GameObject a in audio)
            {
                Destroy(a);
            }
            Cargar.CargarEscena(Cargar.escenas.Menu);
        }
    }
}
