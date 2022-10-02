using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor.TypeSearch;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public int lossCounter = 0;
    public static VoiceManager Instance;
    public AudioSource[] audioSources;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        switch (lossCounter)
        {
            case 0:
                audioSources[0].Play();
                break;
            
            case 1:
                audioSources[1].Play();
                break;
            
            default:
                audioSources[0].Play();
                break;
        }
    }

    private void Start()
    {
        
    }
}
