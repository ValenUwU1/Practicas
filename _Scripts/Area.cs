using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public GameObject pj;
    public Transform Pj;
    public void Awake()
    {
        Physics2D.IgnoreLayerCollision(1, 3, true);
        Physics2D.IgnoreLayerCollision(1, 0, true);
    }
    void Update()
    {
        gameObject.transform.position = Pj.transform.position;
    }
}
