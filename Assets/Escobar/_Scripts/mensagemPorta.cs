using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mensagemPorta : MonoBehaviour
{
    public Text texto;
    private GameObject jogador;
    void Start()
    {
        texto.enabled = false;

        jogador = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
