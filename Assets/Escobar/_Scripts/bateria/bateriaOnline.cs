using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bateriaOnline : MonoBehaviour
{
    public int qtdMaxBaterias;
    public int qtdBaterias;
    public GameObject ObjetoBateria;
    public GameObject[] MarcacoesBaterias;

    // Start is called before the first frame update
    void Start()
    {
        qtdBaterias = qtdMaxBaterias;
        AdicionaBateriasCenario();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RemoveBateria()
    {
        qtdBaterias = qtdBaterias - 1;
        //AdicionaBateriasCenario();
    }
    public void AdicionaBateriasCenario()
    {
        //enquanto ainda houver baterias
        if (qtdBaterias > 0)
        {
            GameObject[] bateriaList = new GameObject[qtdBaterias];

            int rand, aux;

            rand = Random.Range(0, MarcacoesBaterias.Length);
            aux = rand;

            //Montando array de baterias
            for (int b = 0; b < qtdBaterias; b++)
            {
                //Adicionando aleatoriamente
                while (aux == rand)
                {
                    rand = Random.Range(0, MarcacoesBaterias.Length);
                }

                //Criando o objeto bateria
                bateriaList[b] = (GameObject)Instantiate(ObjetoBateria);
                bateriaList[b].transform.position = MarcacoesBaterias[rand].transform.position;
                aux = rand;
            }
        }
    }

}
