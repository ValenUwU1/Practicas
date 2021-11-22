using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Cargar
{

    public enum escenas
    {
    Menu,
    Tuto1,
    Tuto2,
    Pastillas,
    Nivel1,
    Nivel2,
    Nivel3,
    Fin,
    PantallaCarga
    }
    private static Action LlamarCarga;
    public static void CargarEscena(escenas escena)
    {
        LlamarCarga = () =>
        {
            SceneManager.LoadScene(escena.ToString());
        }; SceneManager.LoadScene(escenas.PantallaCarga.ToString());
    }
    public static void Carga()
    {
        if (LlamarCarga != null)
        {
            LlamarCarga();
            LlamarCarga = null;
        }
    }

}
