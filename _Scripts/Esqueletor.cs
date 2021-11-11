using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueletor : MonoBehaviour
{
    public float _vel = 1f;
    public Collider2D Col;
    public GameObject Alma,camara,HitboxFake;
    public Transform Esqueleto, alma;
    public Rigidbody2D _Rb2d;
    public Animator animator;
    public SpriteRenderer sprite;
    private bool TieneControl = false;
    private void Awake()
    {
        HitboxFake.SetActive(false);
    }
    void FixedUpdate()
    {
        if (TieneControl)
        {
            if (Input.GetKey("d"))
            {
                _Rb2d.velocity = new Vector2(_vel, _Rb2d.velocity.y);
                sprite.flipX = false;
                animator.SetBool("Mover", true);
            }
            else if (Input.GetKey("a"))
            {
                _Rb2d.velocity = new Vector2(-_vel, _Rb2d.velocity.y);
                sprite.flipX = true;
                animator.SetBool("Mover", true);
            }
            else
            {
                animator.SetBool("Mover", false);
            }
            if (Input.GetKey("m"))
            {
                Morir();
            }
            if (Col != null && Input.GetKey("e"))
            {
                StartCoroutine("UsarPalanca");
            }
        }
    }
    public void Resucitar()
    {
        camara.transform.parent = Esqueleto;
        StartCoroutine("rez");
    }
    public void Morir()
    {
        if (TieneControl)
        {
            StartCoroutine("Efear");
        }
    }
    //Los IEnumerator son god
    IEnumerator rez()
    {
        HitboxFake.SetActive(true);
        Alma.transform.parent = Esqueleto;
        yield return new WaitForSeconds(1f);
        Alma.SetActive(false);
        animator.SetBool("Vivo", true);
        yield return new WaitForSeconds(1f);
        TieneControl=true;
    }
    IEnumerator Efear()
    {
        HitboxFake.SetActive(false);
        TieneControl = false;
        animator.SetBool("Vivo", false);
        yield return new WaitForSeconds(1f);
        Alma.SetActive(true);
        camara.transform.parent = alma;
        Alma.transform.parent = null;
        AlmaControl.AlmaTieneControl = true;
    }
    IEnumerator UsarPalanca()
    {
        HitboxFake.SetActive(false);
        TieneControl = false;
        Col.SendMessage("Activar");
        animator.SetBool("UsarPalanca", true);
        yield return new WaitForSeconds(1f);
        Esqueleto.transform.tag = "Untagged";
        Alma.SetActive(true);
        camara.transform.parent = alma;
        Alma.transform.parent = null;
        AlmaControl.AlmaTieneControl = true;
    } 
    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Trigger"))
        {
            Col = c;
        }
    }
    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Trigger"))
        {
            Col = c;
        }
    }
}
