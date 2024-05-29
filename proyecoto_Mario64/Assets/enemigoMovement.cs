using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemigoMovement : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    //public Animator ani;
    public Quaternion angulo;
    public float grado; 
    public Rigidbody rb;

    public GameObject target; 

    // Start is called before the first frame update
    void Start()
    {
        //ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        comportamiento();
    }
    public  void comportamiento()
    {
        if(Vector3 .Distance(transform.position, target.transform.position) > 5)
        {
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
                switch (rutina)
                {
                    case 0:
                        //ani.SetBool("walk", false);
                        break;
                    case 1:
                        grado = Random.Range(0, 360);
                        angulo = Quaternion.Euler(0, grado, 0);
                        rutina++;
                        break;
                    case 2:
                        rb.transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                        rb.transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                        //ani.setBool("walk", true);
                        break;

                }
            }
            else
            {
                var lookpos = target.transform.position - transform.position;
                lookpos.y = 0; 
                var rotation = Quaternion.LookRotation(lookpos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                //ani.setBool("walk",false)
                //ani.setBool("run",true)
                transform.Translate(Vector3.forward*2 *Time.deltaTime);
            }

        }
        
    }
}
