using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pontaCabeca : MonoBehaviour
{
    public float velocidade;
    public bool mover = false;

    public GameObject player;

    public AudioSource audio;

    public Animator _animacao;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private float localizacaoZ;
    private void Start()
    {
        _animacao.SetBool("ativar", false);
    }

    private void Update() {
        if(mover) {
            localizacaoZ = transform.position.z;
            localizacaoZ = localizacaoZ +(velocidade * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, localizacaoZ);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(mover==false) {
                _animacao.SetBool("ativar", true);
                _animacao.SetBool("atacar", false);
                audio.Play();
                mover = true; 
                controller.m_WalkSpeed = (0);
            }
            else {
                mover = false;
                audio.Stop();
                _animacao.SetBool("atacar", true);

                //Vector3 playerPos = other.gameObject.CompareTag("Player").transform.position;

                transform.position = new Vector3(player.transform.position.x,player.transform.position.y - 0.5f , player.transform.position.z - 1.3f);
                transform.transform.Rotate(0,0, 180);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
