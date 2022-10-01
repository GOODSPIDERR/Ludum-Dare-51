using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponHit : MonoBehaviour
{
    private Animator weaponAnim;
    public bool canAttack = true;
    Transform mainCamera;
    public GameObject featherVFX;
    public Transform featherSpawn;
    public AudioSource swipeSound, hitSound;
    bool hasHit;
    private float attackTimer = 0f;
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
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
        if (!hasHit)
        {
            //Makes sure that this only triggers once per swing
            hasHit = true;

            //Spawns the feather VFX
            //Instantiate(featherVFX, featherSpawn.position, transform.rotation);

            //Camera shake
            mainCamera.localPosition = new Vector3(0, 0, 0);
            Sequence shakeSequence = DOTween.Sequence();
            shakeSequence.Append(mainCamera.DOShakePosition(0.6f, new Vector3(0.4f, 0.4f, 0f), 30, 10, false, true));
            shakeSequence.Append(mainCamera.DOLocalMove(new Vector3(0, 0, 0), 0.4f));
            shakeSequence.Play();

            //Sound stuff is handled by the Feather VFX prefab now
            //hitSound.pitch = Random.Range(0.95f, 1.05f);
            //hitSound.Play();
        }


        if (other.GetComponent<Rigidbody>() != null) //If the thing you hit happens to have a rigidbody, applies a force in the direction you're facing
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(-direction, ForceMode.Impulse);
        }


    }
}
