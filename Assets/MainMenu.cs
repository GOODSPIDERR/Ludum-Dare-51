using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject blackout;


    public void GoNext()
    {
        blackout.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
