using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.AI.Navigation.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class enemigoMovimiento : MonoBehaviour
{




    public Transform Player;
    private NavMeshAgent agent;
    public Animator ani;

    public GameObject target;

    public float wanderRadius = 10f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 2.5)
        {
            // agregar aca el movimeitno aleatorio del enemigo
            GetRandomDestination();
        }
        else
        {
            agent.destination = Player.position;
        }
    }


    void GetRandomDestination()
    {
        // Obtener un punto aleatorio dentro del radio wanderRadius
        Vector3 randomPoint = Random.insideUnitSphere * wanderRadius;
        randomPoint += transform.position;

        // Asegurar que el punto aleatorio esté en el NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
