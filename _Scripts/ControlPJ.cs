using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPJ : MonoBehaviour
{
    private float _Vel=2;
    public GameObject alma, camara,area;
    public float _FuerzaSalto=5f;
    public Rigidbody2D _Rb2d;
    public Animator animator;
    public SpriteRenderer _Sprd;
    public Transform PJ, Alma;
    public Collider2D coly=null;
    //Ptm me quedo muy spaghetti la semana que viene lo optimizo. Tengo que intentar usar los GetRawAxis
    public static bool TieneControl = true;
    private void Awake()
    {
        alma.SetActive(false);
        area.SetActive(false);
    }
    void FixedUpdate()
    {
        if (TieneControl)
        {
            if (Input.GetKeyDown("w") && TocaPiso())
            {
                _Rb2d.velocity = new Vector2(_Rb2d.velocity.x, _FuerzaSalto);
            }
                //Agacharse
            if (Input.GetKey("s") || ChocaConTecho._TieneAlgoEncima)
            {
                    _Vel = 1;
                    animator.SetBool("Agachado", true);

            }
                //Correr
           else if (Input.GetKey("left shift") && ChocaConTecho._TieneAlgoEncima == false && !Input.GetKey("s"))
           {
               animator.SetBool("Correr", true);
               animator.SetBool("Agachado", false);
               _Vel = 5;
           }
            //Salir de correr y agachar
                    else
                    {
                        _Vel = 2;
                        animator.SetBool("Correr", false);
                        animator.SetBool("Agachado", false);
                    }
                    //caminar e idle.
                    if (Input.GetKey("d"))
                    {
                        _Rb2d.velocity = new Vector2(_Vel, _Rb2d.velocity.y);
                        _Sprd.flipX = false;
                        animator.SetBool("Caminar", true);
                    }
                    else if (Input.GetKey("a"))
                    {
                        _Rb2d.velocity = new Vector2(-_Vel, _Rb2d.velocity.y);
                        _Sprd.flipX = true;
                        animator.SetBool("Caminar", true);
                    }
                    else
                    {
                        _Rb2d.velocity = new Vector2(0, _Rb2d.velocity.y);
                        animator.SetBool("Caminar", false);
                    }
            if (Input.GetKeyDown("e") && coly != null)
            {
                coly.SendMessage("Activar", SendMessageOptions.DontRequireReceiver);
            }
            //Apretar M para morir :D
            if (UsarCianuro.TieneCianuro && Input.GetKeyDown("q"))
            {
                animator.SetBool("Kys", true);
                animator.SetBool("Dead", true);
                TieneControl = false;
                StartCoroutine(Muerte());
            }
        }
        else
        {
            animator.SetBool("Correr", false);
            animator.SetBool("Agachado", false);
            animator.SetBool("Caminar", false);
        }
    }
    void Update()
    {
        if (TocaPiso())
        {
            animator.SetBool("Salto", false);
        }
        else if(!TocaPiso())
        {
            animator.SetBool("Salto", true);
        }
    }
    public LayerMask LayerPiso;
    public float distancia = 1.0f;
    bool TocaPiso()
        {
            Vector2 position = transform.position;
            Vector2 direction = Vector2.down;
            Debug.DrawRay(position, direction, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(position, direction, distancia, LayerPiso);
            if (hit.collider != null)
            {
            animator.SetBool("Salto", false);
            return true;
            }
            return false;
        }
    public void Morir()
    {
        alma.SetActive(true);
        alma.transform.parent = null; camara.transform.parent = Alma;
        AlmaControl.AlmaTieneControl = true;
        area.SetActive(true);
    }
    IEnumerator Muerte()
    {
        TieneControl = false;
        yield return new WaitForSeconds(.25f);
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(1.25f);
        alma.SetActive(true);
        alma.transform.parent = null; camara.transform.parent = Alma;
        AlmaControl.AlmaTieneControl = true;
        area.SetActive(true);
    }
    //Revivir
    public void Resucitar()
    {
        StartCoroutine("RutinaRez");
    }
    IEnumerator RutinaRez()
    {
        alma.transform.parent = PJ; camara.transform.parent = PJ;
        yield return new WaitForSeconds(1f);
        alma.SetActive(false);
        animator.SetBool("Dead", false); 
        animator.SetBool("Kys", false);
        animator.SetBool("MuerteRapida",false);
        yield return new WaitForSeconds(1f);
        area.SetActive(false);
        TieneControl = true;


    }
    private void OnTriggerEnter2D(Collider2D Trigger)
    {
        if (Trigger.gameObject.CompareTag("Trigger")|| Trigger.gameObject.CompareTag("DialogoTrigger"))
        {
            coly =Trigger;
        }
        if (Trigger.CompareTag("Plataforma"))
        {
            transform.parent = Trigger.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D Trigger)
    {
        if (Trigger.gameObject.CompareTag("Trigger") || Trigger.gameObject.CompareTag("DialogoTrigger"))
        {
            coly = null;
        }
        if (Trigger.CompareTag("Plataforma"))
        {
            transform.parent = null;
        }
    }
}
