using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samaPlayVideo : MonoBehaviour
{
    private bool travar = false;

    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (travar)
        {
            //Time.timeScale = 0;
            travar = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<CharacterController>().enabled = false;
            travar = true;
            player.GetComponent<Animator>().SetBool("ativar", true);
            //player.GetComponent<Animator>().Play("Running Crawl", 0, 0.25f);
        }
    }

}
