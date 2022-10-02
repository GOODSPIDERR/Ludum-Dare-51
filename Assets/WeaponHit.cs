using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponHit : MonoBehaviour
{
    private Animator weaponAnim;
    public bool canAttack = true;
    private AudioSource audioSource;
    private Transform playerCamera;
    public LayerMask targetLayer;
    public VoiceManager voiceManager;
    
    bool hasHit;
    private float attackTimer = 0f;
    void Start()
    {
        weaponAnim = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerView").transform;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && canAttack) //If you click LMB and can attack, swings the pillow
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5f, targetLayer))
            {
                if (hit.transform.CompareTag("Target"))
                {
                    var theScript = hit.transform.GetComponent<DisaperTest>();
                    theScript.Disappear();
                    voiceManager.lossCounter++;
                    voiceManager.PlayVoice();
                }
            }
            
            audioSource.Play();
            
            hasHit = false;
            weaponAnim.SetTrigger("Attack");
            canAttack = false;
            attackTimer = 1f;

            //swipeSound.pitch = Random.Range(0.95f, 1.05f);
            //swipeSound.Play();
        }

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            canAttack = true;
        }

        
    }


}
