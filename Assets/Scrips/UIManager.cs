using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public GameObject   panelPrincipal;
    public GameObject   panelPausa;
    public GameObject   gameOver;
    public Image        life;
    public Image        qAbility;
    public PlayerDataSO playerData;
    //public GameEvent    gameOverPart2;

    void Start()
    {
        CleanPanels();
        ShowHUD();
    }
    private void CleanPanels()
    {
        panelPrincipal.SetActive(false);
        panelPausa.SetActive(false);
        gameOver.SetActive(false);
    }

    public void ShowHUD()
    {
        CleanPanels();
        panelPrincipal.SetActive(true);
    }
    public void continuar()
    {
        Time.timeScale = 1;
        CleanPanels();
        panelPrincipal.SetActive(true);
    }
    public void pause()
    {
        Time.timeScale = 0;
        CleanPanels();
        panelPausa.SetActive(true);
    }

    public void gameOverPanel()
    {
        StartCoroutine("gameoverWait");
    }

    // Update is called once per frame
    public void DrawData()
    {
        life.fillAmount = playerData.valueLife;
    }

    public void Qability()
    {
        qAbility.fillAmount = 0f;
        StartCoroutine("wallWait");
    }

    public void salir()
    {
        Application.Quit();
    }

    IEnumerator wallWait()
    {
        yield return new WaitForSeconds(1f);
        qAbility.fillAmount += 0.034f;
        if (qAbility.fillAmount >= 1)
            StopCoroutine("wallWait");
        else
            StartCoroutine("wallWait");
    }

    IEnumerator gameoverWait()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0;
        CleanPanels();
        gameOver.SetActive(true);
        //gameOverPart2.Raise();
    }
}
