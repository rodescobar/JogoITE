using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gritosOnline : MonoBehaviour
{
    
    public GameObject objetoGrito;

    public GameObject[] marcacoes;

    private GameObject grito01, grito02;
    // Start is called before the first frame update
    void Start()
    {
        grito01 = (GameObject)Instantiate(objetoGrito);
        grito02 = (GameObject)Instantiate(objetoGrito);
        ordernarAudios();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ordernarAudios() {
        int rand, aux;
        rand = Random.Range(0, marcacoes.Length);
        aux = rand;

        grito01.transform.position = marcacoes[rand].transform.position;

        while(rand==aux) {
            rand = Random.Range(0, marcacoes.Length);
        }

        grito02.transform.position = marcacoes[rand].transform.position;
    }
}
