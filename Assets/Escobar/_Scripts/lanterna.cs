﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lanterna : MonoBehaviour
{
    public Light luz;

    public GameObject cheio;
    public GameObject meio;
    public GameObject vazio;
    public GameObject acabou;


    public float carga;
    public int cargaMaxima;
    private bool contemCarga = true;

    void Start()
    {
        carga = cargaMaxima;
        cheio.SetActive(true);
        meio.SetActive(false);
        vazio.SetActive(false);
        acabou.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && (contemCarga))
        {
            if (luz.enabled)
            {
                luz.enabled = false;
            }
            else
            {
                luz.enabled = true;
            }
        }

        if (luz.enabled)
        {
            //Vai tirando 1seg do tempo
            carga -= Time.deltaTime;
            luz.intensity = 0.1f + 3 * carga / cargaMaxima;

        }

        if (carga <= 0)
        {
            contemCarga = false;
            luz.enabled = false;
        }
        else
        {
            contemCarga = true;
        }

        if (carga >= cargaMaxima)
        {
            carga = cargaMaxima;
        }

        if (luz.intensity > 2)
        {
            cheio.SetActive(true);
            meio.SetActive(false);
            vazio.SetActive(false);
            acabou.SetActive(false);
        }
        else if (luz.intensity > 1 && luz.intensity <= 2)
        {
            cheio.SetActive(false);
            meio.SetActive(true);
            vazio.SetActive(false);
            acabou.SetActive(false);
        }
        else if (luz.intensity > 0.1f && luz.intensity < 1)
        {
            cheio.SetActive(false);
            meio.SetActive(false);
            vazio.SetActive(true);
            acabou.SetActive(false);
        }
        else
        {
            cheio.SetActive(false);
            meio.SetActive(false);
            vazio.SetActive(false);
            acabou.SetActive(true);
        }
    }
}
