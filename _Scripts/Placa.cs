using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa : MonoBehaviour
{
    public GameObject Objeto1 = null;
    public Animator animator; public string MensajeA = null, MensajeB = null;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")||collision.CompareTag("Esqueleto"))
        {
            NewPuerta.PlacaPisada = true;
            animator.SetBool("Activada", true);
            Objeto1.SendMessage(MensajeA);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Esqueleto"))
        {
            animator.SetBool("Activada", false);
            NewPuerta.PlacaPisada = false;
            Objeto1.SendMessage(MensajeB);
        }
    }
}
