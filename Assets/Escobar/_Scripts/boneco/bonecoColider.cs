using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bonecoColider : MonoBehaviour
{
    public new AudioSource audio;
    public GameObject boneco;

    public RawImage mensagemUi;

    // Start is called before the first frame update
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            audio.Play();
            
            boneco.transform.Rotate(boneco.transform.rotation.x,boneco.transform.rotation.y,-180);
            mensagemUi.enabled = true;
        }
    }
}
