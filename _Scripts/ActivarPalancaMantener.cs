using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPalancaMantener : Palanca
{
    public Animator anim;
    public bool Mantener = false;
    public void Activar()
    {
        ControlPJ.TieneControl = false;
        Mantener = true;
    }
    void FixedUpdate()
    {
        if (Mantener)
        {
            Encender();
            if (!Input.GetKey("e"))
            {
                ControlPJ.TieneControl = true;
                Mantener = false;
            }
        }
        else
        {
            Apagar();
        }
    }
}
