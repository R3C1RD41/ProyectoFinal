using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState currentState;
    public GameEvent OnStartEvent;
    public GameEvent OnPauseEvent;
    public GameEvent OnPlayingEvent;
    public PlayerDataSO playerData;
    void Start()
    {
        currentState = GameState.ON_START;
        Time.timeScale = 1;
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
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
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
