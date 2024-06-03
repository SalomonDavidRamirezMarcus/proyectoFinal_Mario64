
using UnityEngine;
using UnityEngine.AI;


public class enemigoMovimiento : MonoBehaviour
{
    public Transform Player;
    public GameObject target;
    private NavMeshAgent agent;
    public Animator ani;

    public float crono;

    private MovimientoQ mario;

    


    public float wanderRadius = 10f;
    // Start is called before the first frame update
    void Start()
    {
        // inicializaciones
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        mario = FindObjectOfType<MovimientoQ>();
    }
    // Update is called once per frame
    void Update()
    {
        //cronometro de movimiento
        crono += 1 * Time.deltaTime;
        //distancia para seguir enemigo
        if (Vector3.Distance(transform.position, target.transform.position) > 100)
        {
            if (crono >=4) 
            {
                GetRandomDestination();
                crono = 0;
            }
        }
        else
        {
            //seguir enemigo 
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

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró en la colisión es el jugador
        if (other.gameObject.tag == "Player")
        {
            mario.Hit = true;
            Destroy(gameObject);


        }
    }
}
