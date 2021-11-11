using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeñaParaApretarE : MonoBehaviour
{
    [Header("Seña")]
    public GameObject seña;
    private bool JugadorEstaCerca;
    //Te aparece una seña para indicarte que podes interactuar con ese objeto.
    private void Awake()
    {
        JugadorEstaCerca = false;
        seña.SetActive(false);
    }
    private void Update()
    {
        if (JugadorEstaCerca) { 
            seña.SetActive(true);
        } else {
            seña.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Esqueleto"))
        {
            Debug.Log("EstaDentro");
            JugadorEstaCerca = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")|| collision.CompareTag("Esqueleto"))
        {
            JugadorEstaCerca = false;
        }
    }
}
