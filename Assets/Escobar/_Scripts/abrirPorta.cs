using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class abrirPorta : MonoBehaviour
{
    public AudioSource[] sons;
    public Animator _animacao;
    public Text mensagem;

    private bool _portaAberta = false;

    private bool colisaoPlayer = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (colisaoPlayer))
        {
            if (!_portaAberta)
            {
                _animacao.SetBool("abrirPorta", true);
                _animacao.SetBool("fecharPorta", false);
                sons[0].Play();
            }
            else
            {
                sons[0].Stop();
                _animacao.SetBool("abrirPorta", false);
                _animacao.SetBool("fecharPorta", true);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        mensagem.enabled = true;
        colisaoPlayer = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _animacao.SetBool("abrirPorta", false);
        _animacao.SetBool("fecharPorta", true);
        mensagem.enabled = false;
        colisaoPlayer = false;
    }
    /*
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            print("entrou");
            colisaoPlayer = true;
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.CompareTag("Player"))
        {
            print("false");
            colisaoPlayer = false;
        }
    }
     */
}
