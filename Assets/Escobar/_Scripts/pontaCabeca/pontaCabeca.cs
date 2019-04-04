using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pontaCabeca : MonoBehaviour
{
    public Text mensagemFimJogo;
    //Argumentos para funcionamento
    public float velocidade;
    public GameObject player;
    public GameObject referencialPlayer;
    public AudioSource[] audio;
    public Animator _animacao;

    //Para bloquear o player
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
   
    //Variaveis auxiliares
    private bool mover = false;
    private bool reposicionar = false;
    private Vector3 posicaoInicial;

    //Para ataque zombie
    private Vector3 posicaoPlayer;
    private float localY;

    private float localizacaoX;
    private void Start()
    {
        _animacao.SetBool("ativar", false);
        mensagemFimJogo.enabled = false;
    }

    private void Update() {
        //Monstro se movimenta
        if(mover) {
            //_lanterna = gameObject.CompareTag("SpotLight");
            //Para não mexer em Y, pega posicao do player e fixa em + 2
            float posicaoY = referencialPlayer.transform.position.y +1f;
            posicaoPlayer = new Vector3(referencialPlayer.transform.position.x, posicaoY, referencialPlayer.transform.position.z);

            //Olhar para a zombie
            controller.transform.LookAt(transform.position);

            //Movimentar zombie
            localizacaoX = (velocidade * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, posicaoPlayer, localizacaoX);
        }
        else if(reposicionar){
            float posX = transform.position.y;
            //controller.transform.LookAt(posicaoInicial);

        }

        if(mensagemFimJogo.enabled && (Input.GetKeyDown(KeyCode.Return))) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(mover==false) {
                audio[1].Play();
                audio[0].Play();
                
                _animacao.SetBool("ativar", true);
                _animacao.SetBool("atacar", false);
                
                
                //controller.m_WalkSpeed = (0); Bloqueia teclas W A S D
                controller.enabled = false; // Bloqueia todo o player

                //direcionamento do monstro e da visao do player
                //utilizando a referencia

                //apontar camera para o monstro.
                posicaoInicial = transform.position;
                player.transform.LookAt(posicaoInicial);

                //posicaoInicial = transform.position; //Pega a posiação inicial do Monstro, para o player seguir.

                mover = true; 
            }
            else {
                //Após o monstro andar de ponta cabeca, o player deverá ser reposicionado.
                reposicionar = true; 
                mover = false;
                audio[0].Stop();
                _animacao.SetBool("atacar", true);

                player.transform.LookAt(posicaoInicial);
                transform.position = new Vector3(referencialPlayer.transform.position.x, referencialPlayer.transform.position.y - 1.2f, referencialPlayer.transform.position.z);
                

                //Vector3 playerPos = other.gameObject.CompareTag("Player").transform.position;

                //transform.position = new Vector3(0,_lanterna.transform.position.y, _lanterna.transform.position.z);
                transform.transform.Rotate(0,0, 180);

                //yield WaitForSeconds (3.0);
                mensagemFimJogo.enabled = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
