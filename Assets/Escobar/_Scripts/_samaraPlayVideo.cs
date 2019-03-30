using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatilhoPlayer : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private int travar = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (travar < 1)
        {
            Time.timeScale = 0;
            print("entrou");
            travar = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            travar = 0;
        }
    }
}
