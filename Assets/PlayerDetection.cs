using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{

    public bool instantRestart;
    public GameObject blackout;

    private VoiceManager voiceManager;
    // Start is called before the first frame update
    void Start()
    {
        voiceManager = GameObject.FindGameObjectWithTag("LossCounter").GetComponent<VoiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            voiceManager.lossCounter++;
            if (instantRestart) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            else blackout.SetActive(true);
        }
    }
}
