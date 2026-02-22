using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToggler : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void Toggle()
    {
        if (audioSource.isPlaying) audioSource.Stop();
        else audioSource.Play(); 
    }
}
