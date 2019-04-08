using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieNTE : MonoBehaviour
{
    public new AudioSource audio;

    public Animator _animacao;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animacao.SetBool("ativar", true);
            audio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animacao.SetBool("ativar", false);
            audio.Stop();
        }
    }

}
