using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject panelPrincipal;
    public GameObject panelNivel;
    public GameObject PanelAbout;
    public Image nivel1;
    public TextMeshProUGUI nivel234;
    private int nivel;
    void Start()
    {
        nivel = 0;
        CleanPanels();
        ShowHUD();
    }
    private void CleanPanels()
    {
        panelPrincipal.SetActive(false);
        panelNivel.SetActive(false);
        PanelAbout.SetActive(false);
    }

    private void CleanImages()
    {
        nivel1.gameObject.SetActive(false);
        nivel234.gameObject.SetActive(false);
    }

    public void showNivel1()
    {
        CleanImages();
        nivel1.gameObject.SetActive(true);
        nivel = 1;
    }

    public void showNivel234()
    {
        CleanImages();
        nivel234.gameObject.SetActive(true);
        //nivel234.text = "En desarrollo";
        nivel = 2;
    }

    public void ShowHUD()
    {
        CleanPanels();
        panelPrincipal.SetActive(true);
    }

    public void ShowNiveles()
    {
        CleanPanels();
        panelNivel.SetActive(true);
    }

    public void ShowAbout()
    {
        CleanPanels();
        PanelAbout.SetActive(true);
    }

    public void toLV1()
    {
        if (nivel == 1)
            SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
