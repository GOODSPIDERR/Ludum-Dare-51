using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    public CameraShake cameraShake;
    void Start()
    {
        StartCoroutine(Every10());
    }

    private IEnumerator Every10()
    {
        Debug.Log("Something happened");
        cameraShake.Shake(6f, 3f, 1f);
        yield return new WaitForSeconds(2);
        StartCoroutine(Every10());
    }
}
