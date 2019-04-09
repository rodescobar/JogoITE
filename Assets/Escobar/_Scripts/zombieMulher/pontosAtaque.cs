using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pontosAtaque : MonoBehaviour
{

    public aiPatrolPontos zombieFeminina;
    void Start()
    {
        zombieFeminina.GetComponent<aiPatrolPontos>();
    }
    void Update()
    {        
        //print(item.podeAtacar);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            zombieFeminina.podeAtacar = false;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            zombieFeminina.podeAtacar = true;
        }
    }
}
