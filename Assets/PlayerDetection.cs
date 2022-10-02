using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{

    public bool instantRestart;
    public GameObject blackout;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (instantRestart) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            else blackout.SetActive(true);
        }
    }
}
