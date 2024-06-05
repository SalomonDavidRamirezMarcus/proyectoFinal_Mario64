
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

    private bool atacando;






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
        ani.SetBool("ataque", false);
        ani.SetBool("caminar", false);
        //cronometro de movimiento
        crono += 1 * Time.deltaTime;
        //distancia para seguir enemigo
        if (Vector3.Distance(transform.position, target.transform.position) > 80)
        {
            if (crono >=6) 
            {
                GetRandomDestination();
                crono = 0;
               new WaitForSeconds(3f);

            }
        }
        else
        {
            if(Vector3.Distance(transform.position, target.transform.position) > 10 && !atacando)
            {
                ani.SetBool("ataque", false);
                ani.SetBool("caminar", true);
                //seguir enemigo 
                agent.destination = Player.position;
            }
            else
            {
                ani.SetBool("caminar",false);
                ani.SetBool("ataque", true);
                atacando = true;

                new WaitForSeconds(10f);

                
                atacando = false;
            }
        }
    }

    void GetRandomDestination()
    {
        // Obtener un punto aleatorio dentro del radio wanderRadius
        Vector3 randomPoint = Random.insideUnitSphere * wanderRadius;
        randomPoint += transform.position;
        ani.SetBool("ataque", false);
        ani.SetBool("caminar", true);

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

            ani.SetBool("muerte", true);
            new WaitForSeconds(4f);

            Destroy(gameObject);


        }
    }
}
