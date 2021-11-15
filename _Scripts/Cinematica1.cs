using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematica1 : MonoBehaviour
{
    //Poggers otro script hecho por mí solito
    public GameObject SueloCinematica, Alma, SueloCinematica2,chara;
    public Transform pj;
    public Animator animator;
    public static int secuencia = 0;
    void Update()
    {
        if (ControlPJ.TieneControl&&secuencia==0)
        {
            SueloCinematica.SetActive(false);
            StartCoroutine("Cinematica");
            animator.SetBool("EnCinematica", true);
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
            Destroy(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        int sec2 = 0;
        if (c.CompareTag("Player")&&sec2==0)
        {
            animator.SetBool("MuerteRapida", true);
            sec2++;
        }
    }
}
