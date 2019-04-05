using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiPatrolPontos : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;

    private int randomSpots;

    public NavMeshAgent agent;

    private float esperar;
    public float tempoEspera;
    private int marcador;

    public Animator animator;
    public AudioSource[] audio;

    private bool podeAndar = true;
    private bool atacarPlayer = false;
    private float tempoGrito = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        esperar = tempoEspera;
        //randomSpots = Random.Range(0, lenght de marcacoes);
        marcador = Random.Range(0, 2) == 0 ? 1 : 2;

        animator = GetComponent<Animator>();
        animator.SetInteger("situacao",1);
    }

    // Update is called once per frame
    void Update()
    {
        if(!atacarPlayer) {
            MovimentaMarcacao();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetInteger("situacao",2);
            atacarPlayer = true;
            audio[0].Play();
            //animator.SetInteger("situacao",3);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetInteger("situacao",1);
            atacarPlayer = false;
        }
    }    

    private void MovimentaMarcacao() {
        //transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpots].position, speed * Time.deltaTime);

        if ((Vector3.Distance(transform.position, moveSpots[marcador].position) <= 0.6f) && (podeAndar))
        {
            animator.SetInteger("situacao",0);
            podeAndar = false;
        }
        else if (!podeAndar)
        {
            //animator.SetBool("andar", true);
            esperar -= Time.deltaTime;
            if (esperar <= 0)
            {
                animator.SetInteger("situacao",1);
                if (marcador == 0)
                {
                    marcador = Random.Range(0, 2) == 0 ? 1 : 3;
                }
                else if (marcador == 1)
                {
                    marcador = Random.Range(0, 2) == 0 ? 0 : 2;
                }
                else if (marcador == 2)
                {
                    marcador = Random.Range(0, 2) == 0 ? 1 : 3;
                }
                else
                {
                    marcador = Random.Range(0, 2) == 0 ? 0 : 2;
                }
                esperar = tempoEspera;
                podeAndar = true;
            }

        }
        else if (podeAndar)
        {
            animator.SetInteger("situacao",1);
            agent.SetDestination(Vector3.MoveTowards(transform.position, moveSpots[marcador].position, speed * Time.deltaTime));
        }        
    }
}
