using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public GameObject panelPrincipal;
    public GameObject panelPausa;


    // Start is called before the first frame update
    public void continuar()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
        panelPrincipal.SetActive(true);
    }
    public void pause()
    {
        Time.timeScale = 0;
        panelPausa.SetActive(true);
        panelPrincipal.SetActive(false);
    }

    // Update is called once per frame
    private void DrawData()
    {

    }

    public void salir()
    {
        Application.Quit();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
}
