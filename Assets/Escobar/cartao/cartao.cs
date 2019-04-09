using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cartao : MonoBehaviour
{
    public Text mensagem;
    private bool podePegar;
    public bool pegouCartao = false;

    // Start is called before the first frame update
    void Start()
    {
        mensagem.enabled = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && (podePegar))
        {
            mensagem.enabled = false;
            pegouCartao = true;
            transform.position = new Vector3(0,0,0);
        }
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Player")) {
            mensagem.enabled = true;
            podePegar = true;            
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.CompareTag("Player")) {
            mensagem.enabled = false;
            podePegar = false;            
        }
    }
}
