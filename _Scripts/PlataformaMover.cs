using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMover : MonoBehaviour
{
    public bool Funca = false, lugar;
    public float vel = .1f;
    public Transform PosA, PosB, Plataforma;
    public void Encendido()
    {
        Funca = true;
    }
    public void Apagado()
    {
        Funca = false;
    }
    public void FixedUpdate()
    {
        if (Funca)
        {
            if (lugar)
            {
                transform.position = Vector3.MoveTowards(transform.position, PosB.position, vel * Time.fixedDeltaTime);
            }
            else if (!lugar)
            {
                transform.position = Vector3.MoveTowards(transform.position, PosA.position, vel * Time.fixedDeltaTime);
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Piso")
        {
            lugar = !lugar;
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Punto")
        {
            lugar = !lugar;
        }
    }
}
