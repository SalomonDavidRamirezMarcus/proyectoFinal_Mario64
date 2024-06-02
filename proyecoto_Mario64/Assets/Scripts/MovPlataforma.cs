using UnityEngine;

public class MovPlataforma : MonoBehaviour
{
    public Transform pointA; // Punto A
    public Transform pointB; // Punto B
    public float speed = 1.0f; // Velocidad de la plataforma

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float journeyLength;
    private float startTime;

    private void Start()
    {
        startPosition = pointA.position;
        endPosition = pointB.position;
        journeyLength = Vector3.Distance(startPosition, endPosition);
        startTime = Time.time;
    }

    private void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(fractionOfJourney, 1.0f));
    }
}