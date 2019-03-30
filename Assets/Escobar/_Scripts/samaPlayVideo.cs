using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class samaPlayVideo : MonoBehaviour {

    public GameObject monstro;

    public VideoPlayer video;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    // Update is called once per frame
    void Update () {
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {

            monstro.GetComponent<Animator> ().SetBool ("ativar", true);
            video.Play ();

            controller.m_WalkSpeed = (0);
        }
    }

}