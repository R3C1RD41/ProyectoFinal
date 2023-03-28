using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameState currentState;
    public GameEvent OnStartEvent;
    public GameEvent OnPauseEvent;
    public GameEvent OnPlayingEvent;
    public PlayerDataSO playerData;
    public int eventoBarrera;
    public RecordData records;
    public PlayerData playerData2;
    public string filename;
    public GameObject[] barreraEntrada;

    void Start()
    {
        eventoBarrera = 1;
        currentState = GameState.ON_START;
        Time.timeScale = 1;
        LoadData();
        EvaluateState();
    }
    public void EvaluateState()
    {
        switch (currentState)
        {
            case GameState.ON_START:
                OnStartEvent.Raise();
                playerData.Playin();
                break;
            case GameState.PAUSE:
                OnPauseEvent.Raise();
                break;
            case GameState.PLAYING:
                OnPlayingEvent.Raise();
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.PAUSE)
            {
                currentState = GameState.PLAYING;
                playerData.Playin();
            }
            else
            {
                currentState = GameState.PAUSE;
                playerData.NoPlayin();
            }
            EvaluateState();
        }
    }

    public void resetLv1()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void deshabilitarBarrera()
    {
        if (eventoBarrera < 2)
        {
            barreraEntrada[1].SetActive(false);
            barreraEntrada[3].SetActive(false);
        }
        else
        {
            barreraEntrada[0].SetActive(false);
            barreraEntrada[2].SetActive(false);
            barreraEntrada[4].SetActive(false);
        }
        eventoBarrera++;
    }

    public void LoadData()
    {
        playerData2 = new PlayerData();
        if (File.Exists(Application.dataPath + "/data.json"))
        {
            string objString = File.ReadAllText(Application.dataPath + "/data.json");
            playerData2 = JsonUtility.FromJson<PlayerData>(objString);
            records.record1 = playerData2.record1;
            records.record2 = playerData2.record2;
            records.record3 = playerData2.record3;
            records.kills1 = playerData2.kills1;
            records.kills2 = playerData2.kills2;
            records.kills3 = playerData2.kills3;
            records.deads1 = playerData2.deads1;
            records.deads2 = playerData2.deads2;
            records.deads3 = playerData2.deads3;
        }
    }
}


public enum GameState
{
    LOADING,
    ON_START,
    PLAYING,
    GAME_OVER,
    PAUSE
}
