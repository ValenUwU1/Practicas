using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    public bool Funca; public Animator animator; 
    public void Levantar()
    {
        if (!Funca)
            Estado(true);
    }
    public void Bajar()
    {
        if (Funca)
            Estado(false);
    }
    public void Estado(bool Encendido)
    {
        Funca = Encendido;
        animator.SetBool("Levantar", Encendido);
    }
}
