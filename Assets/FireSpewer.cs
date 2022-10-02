using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpewer : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 raycastDirection;
    public Transform fireballPoint;
    public GameObject fireball;
    public bool canFire;
    private float fireballCooldown;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("PlayerView").transform;
    }
    
    void Update()
    {
        raycastDirection = playerTransform.position - transform.position;
        fireballCooldown -= Time.deltaTime;

        if (fireballCooldown <= 0f) canFire = true;
        else canFire = false;
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, raycastDirection);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, raycastDirection, out hit, 16))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("I see you...");

                if (canFire)
                {
                    Instantiate(fireball);
                    fireballCooldown = 2f;
                }
            }
            
        }
    }
    
}
