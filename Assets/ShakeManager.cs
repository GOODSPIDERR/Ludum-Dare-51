using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class ShakeManager : MonoBehaviour
{
    public VolumeProfile volumeProfile;
    private Vignette vignette;
    private FilmGrain filmGrain;
    private LensDistortion lensDistortion;
    private ChromaticAberration chromaticAberration;
    private AudioSource heartbeat1, heartbeat2, heartbeat3;
    public CameraShake cameraShake;
    public GameObject[] platforms;
    public AudioSource[] obstacleAudios;
    void Start()
    {
        volumeProfile.TryGet<Vignette>(out vignette);
        volumeProfile.TryGet<FilmGrain>(out filmGrain);
        volumeProfile.TryGet<LensDistortion>(out lensDistortion);
        volumeProfile.TryGet<ChromaticAberration>(out chromaticAberration);
        
        platforms = GameObject.FindGameObjectsWithTag("MovingPlatform");
        heartbeat1 = GetComponent<AudioSource>();
        StartCoroutine(Every10());
    }

    private IEnumerator Every10()
    {
        Debug.Log("Something happened...");
        cameraShake.Shake(8f, 4f, 3f);
        heartbeat1.Play();

        foreach (var platform in platforms)
        {
            platform.transform.DOMoveY(Random.Range(-30f, -20f), 2f);
        }

        vignette.intensity.value = 0.5f;
        DOTween.To(() => vignette.intensity.value, x => vignette.intensity.value = x, 0f, 2f);

        filmGrain.intensity.value = 1f;
        DOTween.To(() => filmGrain.intensity.value, x => filmGrain.intensity.value = x, 0f, 4f);
        
        lensDistortion.intensity.value = -0.5f;
        DOTween.To(() => lensDistortion.intensity.value, x => lensDistortion.intensity.value = x, 0f, 2f);

        chromaticAberration.intensity.value = 1f;
        DOTween.To(() => chromaticAberration.intensity.value, x => chromaticAberration.intensity.value = x, 0f, 2f);

        foreach (var audioSource in obstacleAudios)
        {
            audioSource.Play();
        }
        
        //Always end with this
        yield return new WaitForSeconds(10);
        StartCoroutine(Every10());
    }
}
