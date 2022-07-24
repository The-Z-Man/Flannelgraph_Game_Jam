using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkerBehaviour : MonoBehaviour
{
    // ----------------------------- Movement Setup ---------------------------

    [Tooltip("The AI movement speed."), SerializeField]
    private float movementSpeed;
    [Tooltip("The AI jump height."), SerializeField]
    private float jumpHeight;

    private bool isGrounded = false;
    private Vector3 lastPos;

    // ------------------------------ Detection Setup -------------------------

    [Space, Tooltip("The area the AI percieves the player in."), SerializeField]
    private float perceptionRadius;
    [Tooltip("The area the AI loses the player if they leave."), SerializeField]
    private float escapeRadius;

    // ------------------------------ General Setup ---------------------------

    private Rigidbody2D rb2d;
    private GameObject trackedPlayer = null;

    // -------------------------------- Startup -------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // --------------------------------- Events -------------------------------

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    // --------------------------- Frame Dependant Code -----------------------

    // Update is called once per frame
    void Update()
    {
        if (trackedPlayer == null)
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, perceptionRadius, Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.tag == "Player")
                {
                    trackedPlayer = hit.collider.gameObject;
                    break;
                }
            }
        }

        if (trackedPlayer != null && Vector2.Distance(transform.position, trackedPlayer.transform.position) > escapeRadius)
        {
            trackedPlayer = null;
        }
    }

    void FixedUpdate()
    {
        if (trackedPlayer != null)
        {

            Vector2 newVelocity = rb2d.velocity;

            newVelocity.x = (trackedPlayer.transform.position.x > transform.position.x) ?
                movementSpeed * Time.fixedDeltaTime : -movementSpeed * Time.fixedDeltaTime;

            if (Vector3.Distance(transform.position, lastPos) < 0.01f && isGrounded)
            {
                newVelocity.y = jumpHeight;
                isGrounded = false;
            }

            rb2d.velocity = newVelocity;
            lastPos = transform.position;
        }
    }
}
