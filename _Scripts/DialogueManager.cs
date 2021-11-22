using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text NombreTexto;
    public Text DialogoTexto;
    public Queue<string> Oraciones;
    public Queue<float> Velocidad;
    public bool PasarDialogo;
    public Animator animator;
    public static bool EnDialogo;
    private void Start()
    {
        Oraciones = new Queue<string> { };
        Velocidad = new Queue<float> { };
    }
    public void ComenzarDialogo(Dialogo dialogo)
    {
        NombreTexto.text = dialogo.nombre;
        Oraciones.Clear();
        Velocidad.Clear();
        animator.SetBool("Activada", true);
        foreach (string oracion in dialogo.frases)
        {
            Oraciones.Enqueue(oracion);
        }
        foreach (float velocidad in dialogo.velocidadtexto)
        {
            Velocidad.Enqueue(velocidad);
        }
        MostrarDialogo();
    }
    public void MostrarDialogo()
    {
        PasarDialogo = false;
        if (Oraciones.Count == 0)
        {
            SalirDialogo();
            return;
        }
        string Oracion = Oraciones.Dequeue();
        StopAllCoroutines();
        StartCoroutine(EscribirDialogo(Oracion));
    }
    IEnumerator EscribirDialogo(string Oracion)
    {
        DialogoTexto.text = "";
        float VelDialogo = Velocidad.Dequeue();
        foreach (char letra in Oracion.ToCharArray())
        {
            DialogoTexto.text += letra;
            if (VelDialogo != 0)
            {
                yield return new WaitForSeconds(VelDialogo);
            }
            else
            {
                yield return null;
            }
        }
        PasarDialogo = true;
    }
    public void Update()
    {
        if (Input.GetKey("return")&& PasarDialogo)
        {
            MostrarDialogo();
        }
    }
    public void SalirDialogo()
   {
        animator.SetBool("Activada", false);
        ControlPJ.TieneControl = true;
        EnDialogo = false;
    }
}
