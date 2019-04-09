using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fimConseguiu : MonoBehaviour
{

    public RawImage imagemFim;
    // Start is called before the first frame update
    void Start()
    {
        imagemFim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(imagemFim.enabled && Input.GetKeyDown(KeyCode.Return)) {
            //imagemFim.enabled = false;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
