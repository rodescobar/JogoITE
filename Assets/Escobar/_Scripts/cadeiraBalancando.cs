using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cadeiraBalancando : MonoBehaviour
{
    public AudioSource _audio;
    public GameObject _apoioBalanco;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _audio.Stop();
        _anim = _apoioBalanco.GetComponent<Animator>();
        _anim.SetBool("ativo", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audio.Play();
            _anim.SetBool("ativo", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _audio.Stop();
        _anim.SetBool("ativo", false);
    }
}
