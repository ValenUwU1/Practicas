using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    private bool pausado = false;
    public GameObject iconopausa;
    void Update()
    {
        if (Input.GetKeyDown("p") && !pausado&& !DialogueManager.EnDialogo)
        {
            Time.timeScale = 0f;
            pausado = true;
            iconopausa.SetActive(true);
        }
        else if (pausado)
        {
            if (Input.GetKeyDown("p"))
            {
                Time.timeScale = 1f;
                pausado = false;
                iconopausa.SetActive(false);
            }
            else if (Input.GetKeyDown("escape"))
            {
                Cargar.CargarEscena(Cargar.escenas.Menu);
            }
        }
    }
}
