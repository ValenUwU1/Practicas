using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa : MonoBehaviour
{
    public GameObject Objeto1 = null,Objeto2=null;
    public Animator animator; public string MensajeA = null, MensajeB = null,MensajeC=null,MensajeD=null;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")||collision.CompareTag("Esqueleto"))
        {
            NewPuerta.PlacaPisada = true;
            animator.SetBool("Activada", true);
            Objeto1.SendMessage(MensajeA);
            if(Objeto2!=null && MensajeC!=null)Objeto2.SendMessage(MensajeC);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Esqueleto"))
        {
            animator.SetBool("Activada", false);
            NewPuerta.PlacaPisada = false;
            Objeto1.SendMessage(MensajeB);
            if (Objeto2 != null && MensajeD != null) Objeto2.SendMessage(MensajeD);
        }
    }
}
