using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bateria : MonoBehaviour
{
    public Text mensagem;
    public GameObject scriptOnline;
    
    public GameObject lanternaScript;

    private bool podePegar = false;
    // Start is called before the first frame update
    void Start()
    {
        mensagem.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (podePegar))
        {
            podePegar = false;
            scriptOnline.GetComponent<bateriaOnline>().RemoveBateria();
            lanternaScript.GetComponent<lanterna>().carga += 150;
            mensagem.enabled = false;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            podePegar = true;
            mensagem.enabled = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            mensagem.enabled = false;
        }
    }

}
