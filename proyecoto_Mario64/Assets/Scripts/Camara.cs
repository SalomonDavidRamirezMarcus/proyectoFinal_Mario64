using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float sensiMouse = 3.0f;
    private float rotY, rotX;

    public Transform target;

    public float distanceTarget = 3.0f;

    Vector3 curRotation;
    Vector3 smoothVelocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private Vector2 MaxMinRota = new Vector2(-20, 40);

    // Start is called before the first frame update
    void Start()
    {
        //Bloqueamos la posicion del mouse y lo desaparecemos de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensiMouse;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensiMouse;

        // Asignams los datos de movimiento y evitamos el "InvertedAxis"
        rotX -= mouseY;
        rotY += mouseX;

        rotX = Mathf.Clamp(rotX, MaxMinRota.x, MaxMinRota.y);
        Vector3 nextRotation = new Vector3(rotX, rotY);
        // Aplicamos entre los cambios de rotacion un efecto de suavizado
        curRotation = Vector3.SmoothDamp(curRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = curRotation;


        transform.position = target.position - transform.forward * distanceTarget;


    }
}