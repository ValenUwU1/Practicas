using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarNivel : MonoBehaviour
{
    public int a =1;
    public void Awake()
    {
        if (a > 3)
        {
            UsarCianuro.TieneCianuro = true;
        }
    }
    public void Update()
    {
        if (Input.GetKey("r"))
        {
            a--;
            Nivel();
        }
    }
    public void Nivel()
    {
        switch (a) {
            case 0:
                Cargar.CargarEscena(Cargar.escenas.Tuto1);
                break;
            case 1:
                Cargar.CargarEscena(Cargar.escenas.Tuto2);
                break;
            case 2:
                Cargar.CargarEscena(Cargar.escenas.Pastillas);
                break;
            case 3:
                Cargar.CargarEscena(Cargar.escenas.Nivel1);
                break;
            case 4:
                Cargar.CargarEscena(Cargar.escenas.Nivel2);
                break;
            case 5:
                Cargar.CargarEscena(Cargar.escenas.Nivel3);
                break;
            case 6:
                Cargar.CargarEscena(Cargar.escenas.Fin);
                break;
            default:
                Cargar.CargarEscena(Cargar.escenas.Menu);
                break;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Nivel();
        }
    }
}
