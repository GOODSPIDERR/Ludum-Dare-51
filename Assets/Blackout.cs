using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blackout : MonoBehaviour
{
    public bool restart;
    public bool endGame;
    void Awake()
    {
        if (!endGame)
        {
            if (restart) StartCoroutine(RestartScene());
            else StartCoroutine(NextScene());
        }
        else
        {
            StartCoroutine(EndGame());
        }
        
    }
    
    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}
