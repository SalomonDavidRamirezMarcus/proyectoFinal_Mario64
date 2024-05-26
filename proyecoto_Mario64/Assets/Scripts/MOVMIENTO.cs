using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVIMIENTO : MonoBehaviour
{
    public float moveSpeed;
    // Velocidad lateral
    public float rotationSpeed;
    private Animator animator;
    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(x * Time.deltaTime * moveSpeed, 0, y * Time.deltaTime * moveSpeed);

        animator.SetFloat("x", x);
        animator.SetFloat("y", y);
    }
}

