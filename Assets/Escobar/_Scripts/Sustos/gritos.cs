using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gritos : MonoBehaviour
{
    public AudioSource[] audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            int somRandomico;
            somRandomico = Random.Range(0, audio.Length);
            audio[somRandomico].Play();
        }
    }
}
