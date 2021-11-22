using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    private GameObject ELADMINDELAUDIO;
    public Audio[] audios;
    private void Awake()
    {
        GameObject[] ELADMINDELAUDIO = GameObject.FindGameObjectsWithTag("Audio");
        if (ELADMINDELAUDIO.Length > 1)
        {
            // :C
            Destroy(this.gameObject);
        }
        else DontDestroyOnLoad(this.gameObject);
;        foreach (Audio clips in audios)
        {
            clips.FuenteAudio= gameObject.AddComponent<AudioSource>();
            clips.FuenteAudio.clip = clips.Clip;
            clips.FuenteAudio.volume = clips.Volumen;
            clips.FuenteAudio.pitch = clips.Dankness;
            clips.FuenteAudio.loop = clips.loop;
        }
    }
    private void Start()
    {
        Play("AyayaVeibaeHell");
    }
    public void Play(string Nombre)
    {
        Audio clips = Array.Find(audios, Audio => Audio.NombreClip == Nombre);
        clips.FuenteAudio.Play();
    }
}
