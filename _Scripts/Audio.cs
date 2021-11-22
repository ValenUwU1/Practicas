using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Audio
{
    public string NombreClip;
    public AudioClip Clip;
    [Range(0f, 2f)]
    public float Volumen;
    [Range(0f, 10f)]
    public float Dankness;
    public bool loop;
    [HideInInspector]
    //Fuente audio MonkaS
    public AudioSource FuenteAudio;
}
