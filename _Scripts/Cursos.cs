using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursos : MonoBehaviour
{
    public int Posicion = 1;
    public Transform cursor;
    public Animator animator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            Posicion++;
        }
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            Posicion--;
        }
        switch (Posicion)
        {
            case 0:
                Posicion = 3;
                break;
            case 1:
                animator.SetInteger("Pos", 1);
                if(Input.GetKey("e")|| Input.GetKey("return"))
                {
                    Cargar.CargarEscena(Cargar.escenas.Tuto1);
                }
                break;
            case 2:
                animator.SetInteger("Pos", 2);
                if (Input.GetKey("e") || Input.GetKey("return"))
                {
                    Cargar.CargarEscena(Cargar.escenas.Fin);
                }
                break;
            case 3:
                animator.SetInteger("Pos", 3);
                if (Input.GetKey("e") || Input.GetKey("return"))
                {
                    Application.Quit();
                }
                break;
            default:
                Posicion = 1;
                break;
        }
    }
}