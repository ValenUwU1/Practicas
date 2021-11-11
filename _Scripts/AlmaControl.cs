using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmaControl : MonoBehaviour
{
    public float _vel=4f;
    public Rigidbody2D _Rb2d;
    public Collider2D Nashe;
    public Animator animator;
    [Header("Se�a")]
    public GameObject se�a;
    public static bool AlmaTieneControl;
    public void Awake()
    {
        animator.SetBool("Fuera", true);
        se�a.SetActive(false);
        animator.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (AlmaTieneControl)
        {
            if (Input.GetKey("d"))
            {
                _Rb2d.velocity = new Vector2(_vel, _Rb2d.velocity.y);
            }
            else if (Input.GetKey("a"))
            {
                _Rb2d.velocity = new Vector2(-_vel, _Rb2d.velocity.y);
            }
            if (Input.GetKey("w"))
            {
                _Rb2d.velocity = new Vector2(_Rb2d.velocity.x, _vel);
            }
            else if (Input.GetKey("s"))
            {
                _Rb2d.velocity = new Vector2(_Rb2d.velocity.x, -_vel);
            }
        }
    }
    public void Update()
    {
        if (Input.GetKey("e") && Nashe != null)
        {
            Nashe.SendMessage("Resucitar");
            AlmaTieneControl = false;
            animator.SetBool("Fuera", false);
        }
    }
    public void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Player") || Col.CompareTag("Esqueleto"))
        {
            Nashe = Col;
            se�a.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D Col)
    {
        if (Col.CompareTag("Player")||Col.CompareTag("Esqueleto"))
        {
            Nashe = null;
            se�a.SetActive(false);
        }
    }
}
