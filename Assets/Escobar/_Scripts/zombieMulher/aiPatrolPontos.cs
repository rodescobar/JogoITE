using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class aiPatrolPontos : MonoBehaviour
{
    public GameObject player;
    public GameObject referencialPlayer;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public Text mensagemFimJogo;

    public float speed;
    public Transform[] moveSpots;

    public NavMeshAgent agent;

    private float esperar;
    public float tempoEspera;
    private int marcador;

    public Animator animator;
    public new AudioSource[] audio;

    public static bool podeAndar = true;
    private bool atacarPlayer = false;

    public bool podeAtacar = false;

    // Start is called before the first frame update
    void Start()
    {
        esperar = tempoEspera;
        //randomSpots = Random.Range(0, lenght de marcacoes);
        marcador = Random.Range(0, 2) == 0 ? 1 : 2;

        animator = GetComponent<Animator>();
        animator.SetBool("andar", true);
        mensagemFimJogo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!atacarPlayer)
        {
            MovimentaMarcacao();
        }
        else
        {
            MovimentaPlayer();
        }

        if(mensagemFimJogo.enabled && (Input.GetKeyDown(KeyCode.Return))) {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        //Achou o player, gritar
        if (col.gameObject.CompareTag("Player") && (!atacarPlayer) && (podeAtacar))
        {
            atacarPlayer = true;
            podeAndar = false;

            //Gritar
            animator.SetBool("andar", false);
            animator.SetBool("correr", true);
            audio[0].Play();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //situacaoAnimacoes(true, false, false, false);
            atacarPlayer = false;
            podeAndar = true;
        }
    }

    private void MovimentaPlayer()
    {
        if (atacarPlayer)
        {
            if ((Vector3.Distance(transform.position, player.transform.position) <= 2f))
            {
                animator.SetBool("atacar", true);
                mensagemFimJogo.enabled = true;

            }
            else
            {
                agent.SetDestination(Vector3.MoveTowards(transform.position, player.transform.position, 6 * speed * Time.deltaTime));

                //Faz player Olhar para a zombie
                player.transform.LookAt(transform.position);
                player.transform.LookAt(referencialPlayer.transform.position);
                controller.enabled = false;

            }
        }
    }

    private void MovimentaMarcacao()
    {
        if (!atacarPlayer)
        {

            if ((Vector3.Distance(transform.position, moveSpots[marcador].position) <= 0.6f) && (podeAndar))
            {
                //Parar
                animator.SetBool("andar", false);
                podeAndar = false;
            }
            else if (!podeAndar)
            {
                //animator.SetBool("andar", true);
                esperar -= Time.deltaTime;
                if (esperar <= 0)
                {
                    //Andar
                    animator.SetBool("andar", true);
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
                animator.SetBool("andar", true);
                agent.SetDestination(Vector3.MoveTowards(transform.position, moveSpots[marcador].position, speed * Time.deltaTime));
            }
        }

    }
}
