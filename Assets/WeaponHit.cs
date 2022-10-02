using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponHit : MonoBehaviour
{
    private Animator weaponAnim;
    public bool canAttack = true;
    public GameObject featherVFX;
    public Transform featherSpawn;
    public AudioSource swipeSound, hitSound;
    bool hasHit;
    private float attackTimer = 0f;
    void Start()
    {
        weaponAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && canAttack) //If you click LMB and can attack, swings the pillow
        {
            hasHit = false;
            weaponAnim.SetTrigger("Attack");
            canAttack = false;
            attackTimer = 0.5f;

            //swipeSound.pitch = Random.Range(0.95f, 1.05f);
            //swipeSound.Play();
        }

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            canAttack = true;
        }
    }

    private void OnTriggerEnter(Collider other) //Screenshake whenever you hit anything
    {
        if (other.CompareTag("Wall"))
        {
            
        }


        if (other.GetComponent<Rigidbody>() != null) //If the thing you hit happens to have a rigidbody, applies a force in the direction you're facing
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(-direction, ForceMode.Impulse);
        }


    }
}
