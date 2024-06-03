using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoQ : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 0.5f;
    public float rotationSpeed = 100f;
    private int jumpCount = 0;
    private bool canJump = true;
    private Rigidbody rb;

    public Animator anima;

    private Dictionary<int, float> initialJumpVelocities = new Dictionary<int, float>();
    private Dictionary<int, float> jumpGravities = new Dictionary<int, float>();

    // cuando golepa a un enemigo salta de nuevo y cuanto va a saltar
    public bool Hit = false;
    public float jumpForce = 100f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetupJumpVariables();
    }

    void Update()
    {
        // Maneja la rotación del personaje
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Rotar al personaje
        transform.Rotate(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        if (Input.GetButtonDown("Jump") && (canJump || jumpCount < 3))
        {
            PerformJump();
        }

        if (verticalInput != 0)
        {
            anima.SetFloat("run", Mathf.Abs(verticalInput));
            Debug.Log("Corriendo");
        }
        else
        {
            anima.SetFloat("run", 0);
            Debug.Log("Quieto");
        }

        // logica cuando le salta al enemigo
        if (Hit)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Hit = false;
        }
    }

    void FixedUpdate()
    {
        // Maneja el movimiento del personaje
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveSpeed * verticalInput;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        // Aplicar gravedad extra si el personaje está cayendo
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * 2f * Time.fixedDeltaTime;
        }
    }

    private void PerformJump()
    {
        float jumpVelocity = initialJumpVelocities[jumpCount + 1];
        float jumpGravity = jumpGravities[jumpCount + 1];

        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity

        rb.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);

        Physics.gravity = new Vector3(0, jumpGravity, 0);

        jumpCount++;


        if (jumpCount >= 3)
        {
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            canJump = true;
            jumpCount = 0; // Reset jump count when touching the ground
            Physics.gravity = new Vector3(0, -9.81f, 0); // Reset gravity to default
        }
    }

    private void SetupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;

        float firstJumpGravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        float firstJumpVelocity = (2 * maxJumpHeight) / timeToApex;

        float secondJumpGravity = (-2 * (maxJumpHeight + 2)) / Mathf.Pow(timeToApex, 2);
        float secondJumpVelocity = (2 * (maxJumpHeight + 2)) / timeToApex;

        float thirdJumpGravity = (-2 * (maxJumpHeight + 4)) / Mathf.Pow(timeToApex, 2);
        float thirdJumpVelocity = (2 * (maxJumpHeight + 4)) / timeToApex;

        initialJumpVelocities.Add(1, firstJumpVelocity);
        initialJumpVelocities.Add(2, secondJumpVelocity);
        initialJumpVelocities.Add(3, thirdJumpVelocity);

        jumpGravities.Add(1, firstJumpGravity);
        jumpGravities.Add(2, secondJumpGravity);
        jumpGravities.Add(3, thirdJumpGravity);
    }
}

