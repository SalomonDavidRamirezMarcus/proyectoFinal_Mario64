using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoQ : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float firstJumpForce = 10f;
    public float secondJumpMultiplier = 1.5f;
    public float thirdJumpMultiplier = 2f;
    private int jumpCount = 0;
    private bool canJump = true;
    public float rotationSpeed = 100f;
    private Rigidbody rb;

    public Animator anima;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Maneja la rotación del personaje
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Rotar al personaje
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);
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
        float jumpForce = firstJumpForce;

        if (jumpCount == 0)
        {
            //anima.SetTrigger("firstJump");
        }
        else if (jumpCount == 1)
        {
            jumpForce *= secondJumpMultiplier;
            //anima.SetTrigger("secondJump");
        }
        else if (jumpCount == 2)
        {
            jumpForce *= thirdJumpMultiplier;
            //anima.SetTrigger("thirdJump");
        }

        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
            Debug.Log("PUEDE SALTAR");
            jumpCount = 0; // Reset jump count when touching the ground
        }
    }
}
