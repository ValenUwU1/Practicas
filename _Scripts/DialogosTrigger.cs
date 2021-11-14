using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosTrigger : MonoBehaviour
{
    public Dialogo _dialogo;
    public bool Scripteado,NuncaMas=false;
    //Dialogos Opcionales
    public void Activar()
    {
        if (!Scripteado)
        {
            FindObjectOfType<DialogueManager>().ComenzarDialogo(_dialogo);
            ControlPJ.TieneControl = false;
        }
    }
    //Dialogos Scripteados
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!NuncaMas)
        {
            if (Scripteado)
            {
                NuncaMas = true;
                FindObjectOfType<DialogueManager>().ComenzarDialogo(_dialogo);
                ControlPJ.TieneControl = false;
            }
        }
    }
}
