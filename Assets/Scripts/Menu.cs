using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject PanelCargando, PanelTrans;
    public Image img_cargando;
    public static bool isCargando;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isCargando == false)
        {
            StartCoroutine(WaitLoaddingMenu());
        }
        else
        {
            PanelCargando.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (img_cargando.fillAmount < 1)
        {
            img_cargando.fillAmount += 0.001f;
        }

        if (img_cargando.fillAmount >= 1)
        {
            isCargando = true;
        }
    }

    IEnumerator WaitLoaddingMenu()
    {
        yield return new WaitForSeconds(4.5f);
        PanelTrans.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        PanelCargando.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        PanelTrans.SetActive(false);
    }

    public void ButtonSelection()
    {
        Application.LoadLevel("Seleccion");
    }
}
