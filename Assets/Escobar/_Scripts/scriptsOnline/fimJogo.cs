using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fimJogo : MonoBehaviour
{
    public Text[] mensagens;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < mensagens.Length; i++)
        {
            mensagens[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Menasgem fim de jogo é sempre 0
        if (mensagens[0].enabled)
        {
            for (int i = 1; i < mensagens.Length; i++)
            {
                mensagens[i].enabled = false;
            }

        }

    }
}
