using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private Vector3 move;
    private float velocityY;
    private float moveSpeed;
    private float acceleration;

    private float gravity;
    private float jumpHeight;
    private float velocityX, velocityZ;
    private Vector3 velocity;

    private CharacterController controller;

    private bool isGrounded;

    private Transform playerTransform;
    private Rigidbody rb;

    private CapsuleCollider collider;
    
    
    public override void EnterState(PlayerMovementScript player)
    {
        moveSpeed = player.moveSpeed;
        acceleration = player.acceleration;
        velocity = player.velocity;

        gravity = player.gravity;
        jumpHeight = player.jumpHeight;


        playerTransform = player.transform;
        controller = player.controller;

        rb = player.rb;
        rb.isKinematic = true;
        velocity = rb.velocity;

        collider = player.capsuleCollider;
        collider.enabled = false;
        controller.enabled = true;
    }
    
    public override void UpdateState(PlayerMovementScript player)
    {
        
        isGrounded = player.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Moving
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");

        var movementVector = new Vector2(x, z).normalized;

        //Makeshift deceleration solution. There must be a more efficient solution
        if (x == 0f) //Decelerate if not moving X
        {
            velocityX *= 0.92f;
        }
        if (z == 0f) //Decelerate if not moving Z
        {
            velocityZ *= 0.92f;
        }

        //I decided to slightly rework how movement is calculated. Looks janky, but feels better
        velocityX += movementVector.x * acceleration;
        velocityZ += movementVector.y * acceleration;

        velocityX = Mathf.Clamp(velocityX, -moveSpeed, moveSpeed);
        velocityZ = Mathf.Clamp(velocityZ, -moveSpeed, moveSpeed);
        
        move = playerTransform.right * velocityX + playerTransform.forward * velocityZ;
        player.move = move;
        
        controller.Move(move * Time.deltaTime); 

        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        //Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
