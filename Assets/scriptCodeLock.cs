using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptCodeLock : MonoBehaviour
{
    public cartao _cartao;

    public RawImage _mensagem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Player")) {
            if(_cartao.pegouCartao) {
                _mensagem.enabled = true;
            }
            else {
                print("você não pegou o cartão");
            }
        }
    }
}
