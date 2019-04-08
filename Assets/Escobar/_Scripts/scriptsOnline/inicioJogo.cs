using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inicioJogo : MonoBehaviour
{
    public RawImage imagemInicio;
    // Start is called before the first frame update
    void Start()
    {
        imagemInicio.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(imagemInicio && Input.GetKeyDown(KeyCode.Return)) {
            imagemInicio.enabled = false;
        }
    }
}
