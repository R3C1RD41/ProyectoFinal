using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public PlayerDataSO playerData;
    public EnemyData enemyData;
    public GameEvent drawUiEvent;
    public GameEvent GameOver;
    void Start()
    {
        playerData.valueLife = 1f;
        playerData.wallLife = 0.50f;
        playerData.numVidas = 1;
        playerData.damage = 0.25f;
        playerData.numEnemigos = 0;
        playerData.gameOver = false;
        drawUiEvent.Raise();
    }

    public void RecieveDamageCommunPavo()
    {
        playerData.valueLife -= enemyData.damage;
        if (playerData.valueLife <= 0)
        {
            playerData.numVidas--;
        }

        if (playerData.valueLife <= 0 && playerData.numVidas <= 0 && !playerData.gameOver)
        {
            GameOver.Raise();
        }
        drawUiEvent.Raise();
    }

}
