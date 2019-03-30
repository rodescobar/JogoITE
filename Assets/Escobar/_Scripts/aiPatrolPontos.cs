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

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        esperar = tempoEspera;
        randomSpots = Random.Range(0, moveSpots.Length);

        animator = GetComponent<Animator>();
        animator.SetBool("parado", false);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpots].position, speed * Time.deltaTime);
        agent.SetDestination(Vector3.MoveTowards(transform.position, moveSpots[randomSpots].position, speed * Time.deltaTime));

        if(Vector3.Distance(transform.position, moveSpots[randomSpots].position) <= 0.6f) {
            animator.SetBool("parado", true);

            if(esperar <= 0) {
                randomSpots = Random.Range(0, moveSpots.Length);
                esperar = tempoEspera;
                animator.SetBool("parado", false);
            }
            else {
                esperar -= Time.deltaTime;
            }
        }
    }
}
