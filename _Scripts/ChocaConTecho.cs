using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocaConTecho : MonoBehaviour
{
    public static bool _TieneAlgoEncima;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Piso"))
        {
            _TieneAlgoEncima = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Piso"))
        {
            _TieneAlgoEncima = false;
        }
    }
}
