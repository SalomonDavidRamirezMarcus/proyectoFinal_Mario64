using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoQ : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;

    public Animator anima;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horinzontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveSpeed * verticalInput;

        Quaternion rotation = Quaternion.Euler(0f, horinzontalInput * rotationSpeed
            * Time.fixedDeltaTime, 0f);

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * rotation);
        
        if (verticalInput > 0 || verticalInput < 0)
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
}
