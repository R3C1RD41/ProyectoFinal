using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;

public class UIManager : MonoBehaviour
{
    public GameObject   panelPrincipal;
    public GameObject   panelPausa;
    public GameObject   gameOver;
    public GameObject   boss;
    public GameObject   win;
    public Image        life;
    public Image        qAbility;
    public Image        shiftAbility;
    public Image[]      numLifes;
    public PlayerDataSO playerData;
    public RecordData   record;
    public TextMeshProUGUI timeWin;
    public PlayerData playerSave;
    public float        timeInGame;
    public float        InittimeInGame;
    public string       filename;


    void Start()
    {
        InittimeInGame = Time.realtimeSinceStartup;
        CleanPanels();
        ShowHUD();
        StartCoroutine("shiftDraw");
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

    public void ShowBoss()
    {
        boss.SetActive(true);
    }

    public void ShowWin()
    {
        win.SetActive(true);
        timeInGame = Time.realtimeSinceStartup - InittimeInGame;

        playerSave.record1 = record.record1;
        playerSave.deads1 = record.deads1;
        playerSave.kills1 = record.kills1;
        playerSave.record2 = record.record2;
        playerSave.deads2 = record.deads2;
        playerSave.kills2 = record.kills2;
        playerSave.record3 = record.record3;
        playerSave.deads3 = record.kills3;
        playerSave.kills3 = record.kills3;

        if (timeInGame < record.record1 || record.record1 == 0)
        {
            record.record1 = timeInGame;
            record.deads1 = playerData.numVidas;
            record.kills1 = playerData.numEnemigos;
            playerSave.record1 = timeInGame;
            playerSave.deads1 = playerData.numVidas;
            playerSave.kills1 = playerData.numEnemigos;
        }
        else if(timeInGame < record.record2 || record.record2 == 0) 
        {
            record.record2 = timeInGame;
            record.deads2 = playerData.numVidas;
            record.kills2 = playerData.numEnemigos;
            playerSave.record2 = timeInGame;
            playerSave.deads2 = playerData.numVidas;
            playerSave.kills2 = playerData.numEnemigos;
        }
        else if(timeInGame < record.record3 || record.record3 == 0)
        {
            record.record3 = timeInGame;
            record.deads3 = playerData.numVidas;
            record.kills3 = playerData.numEnemigos;
            playerSave.record3 = timeInGame;
            playerSave.deads3 = playerData.numVidas;
            playerSave.kills3 = playerData.numEnemigos;
        }
        
        string objString = JsonUtility.ToJson(playerSave);
        File.WriteAllText(Application.dataPath + "/data.json", objString);
        timeWin.text = "" + ((int)(timeInGame / 60)) + " : " + ((int)timeInGame % 60);
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

    public void DrawData()
    {
        life.fillAmount = playerData.valueLife;
        clearAndDrawLifes();
    }

    public void clearAndDrawLifes()
    {

        for (int i = 0; i < 3; i++)
        {
            numLifes[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < playerData.numVidas; i++)
        {
            numLifes[i].gameObject.SetActive(true);
        }
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
    IEnumerator shiftDraw()
    {
        yield return new WaitForSeconds(1f);
        shiftAbility.fillAmount = playerData.stopTimeHability * 0.034f;
        StartCoroutine("shiftDraw");
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
    }
}
