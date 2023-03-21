using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    public GameObject panelPrincipal;
    public GameObject panelNivel;
    public GameObject PanelAbout;
    public GameObject panelRecords;
    public Image nivel1;
    public TextMeshProUGUI nivel234;
    public TextMeshProUGUI record11;
    public TextMeshProUGUI record12;
    public TextMeshProUGUI record13;
    public TextMeshProUGUI record21;
    public TextMeshProUGUI record22;
    public TextMeshProUGUI record23;
    public TextMeshProUGUI record31;
    public TextMeshProUGUI record32;
    public TextMeshProUGUI record33;
    public RecordData records;
    public PlayerData playerData;
    public string filename;
    private int nivel;
    private StreamReader sr;
    void Start()
    {
        nivel = 0;
        CleanPanels();
        ShowHUD();
        LoadData();
    }
    private void CleanPanels()
    {
        panelPrincipal.SetActive(false);
        panelNivel.SetActive(false);
        PanelAbout.SetActive(false);
        panelRecords.SetActive(false);
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

    public void ShowRecords()
    {
        CleanPanels();
        panelRecords.SetActive(true);
        if (records.record1 == 0)
        {
            record11.text = "" + records.record1;
        }
        else
        {
            record11.text = "" + ((int)(records.record1 / 60)) + " : " + ((int)records.record1 % 60);
        }
        if (records.record2 == 0)
        {
            record21.text = "" + records.record2;
        }
        else
        {
            record21.text = "" + ((int)(records.record2 / 60)) + " : " + ((int)records.record2 % 60);
        }
        if (records.record3 == 0)
        {
            record31.text = "" + records.record3;
        }
        else
        {
            record31.text = "" + ((int)(records.record3 / 60)) + " : " + ((int)records.record3 % 60);
        } 
        record12.text = "" + records.kills1;
        record22.text = "" + records.kills2;
        record32.text = "" + records.kills3;
        record13.text = "" + records.deads1;
        record23.text = "" + records.deads2;
        record33.text = "" + records.deads3;
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

    public void LoadData()
    {
        playerData = new PlayerData();
        if (File.Exists(Application.persistentDataPath + "/" + filename))
        {
            sr = new StreamReader(Application.persistentDataPath + "/" + filename);
            string objString = sr.ReadToEnd();
            playerData = JsonUtility.FromJson<PlayerData>(objString);
            sr.Close();
            records.record1 = playerData.record1;
            records.record2 = playerData.record2;
            records.record3 = playerData.record3;
            records.kills1 = playerData.kills1;
            records.kills2 = playerData.kills2;
            records.kills3 = playerData.kills3;
            records.deads1 = playerData.deads1;
            records.deads2 = playerData.deads2;
            records.deads3 = playerData.deads3;
        }
    }
}
