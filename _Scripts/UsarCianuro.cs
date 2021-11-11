using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarCianuro : MonoBehaviour
{
    public static bool TieneCianuro=false;
    public GameObject Bolsita;
    //Apretar E para agarrar la bolsa
    public void Activar()
    {
        Debug.Log("Nice!");
        TieneCianuro = true;
        Bolsita.SetActive(false);
    }
}
