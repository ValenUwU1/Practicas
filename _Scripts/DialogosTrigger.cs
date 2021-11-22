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
            DialogueManager.EnDialogo = true;
            FindObjectOfType<DialogueManager>().ComenzarDialogo(_dialogo);
            ControlPJ.TieneControl = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !NuncaMas && ControlPJ.TieneControl)
        {
            if (Scripteado)
            {
                DialogueManager.EnDialogo = true;
                NuncaMas = true;
                FindObjectOfType<DialogueManager>().ComenzarDialogo(_dialogo);
                ControlPJ.TieneControl = false;
            }
        }
    }
}
