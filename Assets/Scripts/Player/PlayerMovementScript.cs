using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector;
public class PlayerMovementScript : MonoBehaviour
{
    //This script and the script for all the other player states needs some serious re-organizing
    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public Vector3 move;
    

    [HideInInspector] public CapsuleCollider capsuleCollider;

    [Header("Movement Stuff")]
    public float moveSpeed = 8f;
    public float acceleration = 8f;
    
    [Header("Jumping & Gravity Stuff")]
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private float velocityX, velocityZ;

    [HideInInspector]
    public Vector3 velocity;
    public bool isGrounded;
    
    public float swingForce = 500f;

    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public Rigidbody oRb;

    PlayerBaseState currentState;
    public PlayerMoveState MoveState = new PlayerMoveState();
    public PlayerFlyState FlyState = new PlayerFlyState();

    [HideInInspector]
    public LineRenderer lineRenderer;
    
    private void Awake()
    {
        //Getter
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        currentState = MoveState;
        
        currentState.EnterState(this);
        
    }

    private void Update()
    {
        currentState.UpdateState(this);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    
}
