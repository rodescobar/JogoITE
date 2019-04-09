using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniciarPontaCabeca : MonoBehaviour
{
    public GameObject[] itens;
    private int localizacao;
    // Start is called before the first frame update
    void Start()
    {
        localizacao = Random.RandomRange(0,itens.Length);

        for(int i = 0; i < itens.Length; i++) {
            itens[i].SetActive(false);
        }
        itens[localizacao].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
