using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematica1 : MonoBehaviour
{
    public GameObject SueloCinematica, Alma, SueloCinematica2, chara, Dialogo1, boom;
    public Transform pj,PuntoCine;
    public Animator animator; public float velcine;
    public static int secuencia = 0;
    private bool setoff=true;
    public void FixedUpdate()
    {
        if (ControlPJ.TieneControl&&secuencia==0)
        {
            
            SueloCinematica.SetActive(true);
            if (setoff) {
                Dialogo1.SendMessage("Activar"); 
                setoff = false; }
            if (ControlPJ.TieneControl)
            {
                SueloCinematica.SetActive(false);
                StartCoroutine("Cinematica");
                animator.SetBool("EnCinematica", true);
            }
        }
        if (secuencia == 1)
        {
            ControlPJ.TieneControl = true;
            SueloCinematica2.SendMessage("Activar");
            Alma.transform.parent = pj;
            Alma.transform.position = pj.transform.position;
            secuencia++;
        }
        if(secuencia==2 && ControlPJ.TieneControl)
        {
            StartCoroutine("Cinematica");
        }
        if (secuencia == 3 && !ControlPJ.TieneControl)
        {
            AlmaControl.AlmaTieneControl = false; AlmaControl.AlmaTieneControl = false;
            Alma.transform.position = Vector2.MoveTowards(pj.position, PuntoCine.position, velcine * Time.fixedDeltaTime);
            StartCoroutine("Cinematica");
        }
    }
    IEnumerator Cinematica()
    {
        if (secuencia == 0)
        {
            ControlPJ.TieneControl = false;
            yield return new WaitForSeconds(3f);
            Debug.Log("Xd");
            secuencia = 1;
        }
        if (secuencia == 2)
        {
            ControlPJ.TieneControl = false;
            yield return new WaitForSeconds(2f);
            chara.SendMessage("Morir");
            animator.SetBool("EnCinematica", false);
            secuencia = 3;
            yield return null;
        }
        if (secuencia == 3)
        {
            yield return new WaitForSeconds(1f);
            AlmaControl.AlmaTieneControl = true;
            secuencia = 4;
            Destroy(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        int sec2 = 0;
        if (c.CompareTag("Player")&&sec2==0)
        {
            animator.SetBool("MuerteRapida", true);
            FindObjectOfType<AudioManager>().Play("VineBoom");
            sec2++;
        }
    }
}
