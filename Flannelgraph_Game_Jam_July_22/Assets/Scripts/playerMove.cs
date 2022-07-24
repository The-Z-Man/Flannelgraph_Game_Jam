using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    // ------------------------------ Movement Setup --------------------------

    [Tooltip("Controls how fast the player moves."), SerializeField]
    private float movementSpeed = 5f;
    private float horizontal;

    // ------------------------------ Jump Setup --------------------------

    [Tooltip("Controls how high the player jumps."), SerializeField]
    private float jumpHeight = 5f;
    private bool jump;
    private bool isGrounded = false;

    // ------------------------------ General Setup --------------------------

    private Rigidbody2D rb2D;

    // ------------------------------ Startup --------------------------

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    //-------------------------------Collider Events --------------------------

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }


    // ------------------------------ Input Events ----------------------------

    public void OnHorizontal(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.performed;
    }

    // ------------------------------ Frame Dependant Code --------------------------

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.y += 2;
        cameraPos.z = -10;
        Camera.main.transform.position = cameraPos;
    }

    void FixedUpdate()
    {
        Vector2 newMovement = rb2D.velocity;

        newMovement.x = horizontal*movementSpeed*Time.fixedDeltaTime;

        if(jump && isGrounded)
        {
            newMovement.y = jumpHeight;
            isGrounded = false;
        }


        rb2D.velocity = newMovement;
    }
}
