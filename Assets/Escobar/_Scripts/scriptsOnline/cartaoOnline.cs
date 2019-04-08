using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartaoOnline : MonoBehaviour
{
    public GameObject  _cartao;
    public GameObject[] _marcacoes;

    // Start is called before the first frame update
    void Start()
    {
        int local = Random.Range(0, _marcacoes.Length);
        
        _cartao.transform.position = _marcacoes[local].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
