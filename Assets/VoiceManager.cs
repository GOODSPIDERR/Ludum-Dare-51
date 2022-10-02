using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public int lossCounter = 0;
    public AudioSource[] audioSources;
    public AudioSource audioSource, ambience;

    private void Start()
    {
        PlayVoice();
    }

    public void PlayVoice()
    {
        switch (lossCounter)
        {
            case 0:
                audioSources[0].Play();
                break;
            
            case 1:
                audioSources[1].Play();
                audioSource.Play();
                break;
            
            case 2:
                audioSources[2].Play();
                audioSource.Play();
                break;
            
            case 3:
                audioSources[3].Play();
                audioSource.Play();
                break;
            
            case 4:
                audioSources[4].Play();
                audioSource.Play();
                break;
            
            case 5:
                audioSources[5].Play();
                audioSource.Play();
                break;
            
            case 6:
                audioSources[6].Play();
                audioSource.Play();
                break;
            
            case 7:
                audioSources[7].Play();
                audioSource.Play();
                break;
            
            case 8:
                audioSources[8].Play();
                audioSource.Play();
                break;
            
            case 9:
                audioSources[9].Play();
                audioSource.Play();
                break;
            
            case 10:
                audioSources[10].Play();
                ambience.Stop();
                audioSource.Play();
                break;
            
            default:
                audioSources[11].Play();
                audioSource.Play();
                break;
        }
    }
}
