using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmSource;

    public AudioClip background;


    private void Start()
    {
        bgmSource.clip = background;
        bgmSource.Play();
    }
}
