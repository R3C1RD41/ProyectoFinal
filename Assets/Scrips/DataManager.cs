using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public PlayerDataSO playerData;
    public EnemyData enemyData;
    public GameEvent drawUiEvent;
    public GameEvent GameOver;
    public GameEvent LostLife;
    void Start()
    {
        playerData.valueLife = 1f;
        playerData.wallLife = 1f;
        playerData.numVidas = 3;
        playerData.damage = 0.25f;
        playerData.numEnemigos = 0;
        playerData.gameOver = false;
        playerData.checkPointActual = 1;
        playerData.stopTimeHability = 30;
        drawUiEvent.Raise();
    }

    public void RecieveDamageCommunPavo()
    {
        playerData.valueLife -= enemyData.damage;

        if (playerData.valueLife <= 0)
        {
            playerData.numVidas--;
        }

        if (playerData.valueLife <= 0 && playerData.numVidas < 0 && !playerData.gameOver)
        {
            GameOver.Raise();
        }

        if(playerData.valueLife <= 0 && playerData.numVidas >= 0 && !playerData.gameOver)
        {
            LostLife.Raise();
        }

        drawUiEvent.Raise();
    }

    public void reaparecer()
    {
        playerData.valueLife = 1f;
        drawUiEvent.Raise();
    }
}
