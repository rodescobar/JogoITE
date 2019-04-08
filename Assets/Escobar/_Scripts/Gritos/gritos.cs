using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gritos : MonoBehaviour
{
    //Lista de audio possiveis.
    public new AudioSource[] audio;

    public GameObject scriptOnline;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int somRandomico;
            somRandomico = Random.Range(0, audio.Length);
            audio[somRandomico].Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           scriptOnline.GetComponent<gritosOnline>().ordernarAudios();
        }
    }
}
