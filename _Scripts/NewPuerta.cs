using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPuerta : MonoBehaviour
{
    Animator animator;
    public int PalancasParaAbrir;
    public int PalancasBajadas;
    public static  bool PlacaPisada;
    public bool UsaPalancas;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public bool _EstaAbierto;
    //Se explica solo este script
    public void Abrir()
    {
        if (UsaPalancas)
        {
            PalancasBajadas++;
            if (!_EstaAbierto && PalancasBajadas == PalancasParaAbrir)
                Estado(true);
        }
        else
        {
            if (!_EstaAbierto && PlacaPisada)
            {
                Estado(true);
            }
        }
    }
    public void Cerrar()
    {
        if (UsaPalancas)
        {
            PalancasBajadas--;
            if (_EstaAbierto && PalancasBajadas < PalancasParaAbrir)
                Estado(false);
        }
        else
        {
            if (_EstaAbierto && !PlacaPisada)
            {
                Estado(false);
            }
        }
    }
    public void Estado(bool _Abierto)
    {
        _EstaAbierto = _Abierto;
        animator.SetBool("Abierta" , _Abierto);
    }
}
