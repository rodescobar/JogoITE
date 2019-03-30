using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class abrirPorta : MonoBehaviour {
    public AudioSource[] sons;
    public Animator _animacao;
    public Text mensagem;

    private bool _portaAberta = false;

    private bool colisaoPlayer = false;

    void Update () {
        if (Input.GetKeyDown (KeyCode.E) && (colisaoPlayer)) {
            _animacao.SetBool ("abrirPorta", true);
            _animacao.SetBool ("fecharPorta", false);
            sons[0].Play ();
        }

    }
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            mensagem.enabled = true;
            colisaoPlayer = true;
        }
    }
    private void OnTriggerExit (Collider other) {
        _animacao.SetBool ("abrirPorta", false);
        _animacao.SetBool ("fecharPorta", true);
        mensagem.enabled = false;
        colisaoPlayer = false;
    }
}