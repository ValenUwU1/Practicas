using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    public Animator _animator;
    public GameObject Objeto, Objeto2=null, Objeto3=null;
    public string _MensajeActivacion, _MensajeActivacion2, _MensajeActivacion3;
    public string _MensajeDesactivar, _MensajeDesactivar2, _MensajeDesactivar3;
    public bool _EstaActivada=false;
    public void Encender() 
    {
        if (!_EstaActivada) 
            Estado(true); 
    }
    public void Apagar() 
    { 
        if (_EstaActivada)
            Estado(false); 
    }
    public void Interaccion()
    {
        Debug.Log("+3");
        if (_EstaActivada) 
        { 
            Apagar(); 
        }
        else
        { 
            Encender(); 
        }
    }
    public void Estado (bool Encendido)
    {
        _EstaActivada = Encendido;
        _animator.SetBool("EstaSiendoUsada", _EstaActivada);
        if (Encendido)
        {
            if (Objeto != null && !string.IsNullOrEmpty(_MensajeActivacion))
            {
                Objeto.SendMessage(_MensajeActivacion);
            }
            if (Objeto2 != null && !string.IsNullOrEmpty(_MensajeActivacion2))
            {
                Objeto2.SendMessage(_MensajeActivacion2);
            }
            if (Objeto3 != null && !string.IsNullOrEmpty(_MensajeActivacion3))
            {
                Objeto3.SendMessage(_MensajeActivacion3);
            }
        }
        else
        {
            if (Objeto != null && !string.IsNullOrEmpty(_MensajeDesactivar))
            {
                Objeto.SendMessage(_MensajeDesactivar);
            }
            if (Objeto2 != null && !string.IsNullOrEmpty(_MensajeDesactivar2))
            {
                Objeto2.SendMessage(_MensajeDesactivar2);
            }
            if (Objeto3 != null && !string.IsNullOrEmpty(_MensajeDesactivar3))
            {
                Objeto3.SendMessage(_MensajeDesactivar3);
            }
        }
    }
}
