using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public int numVidas;
    public int numEnemigos;
    public float valueLife;
    public bool playing;
    public bool gameOver;
    public float damage;
    public float wallLife;

    public void NoPlayin()
    {
        playing = false;
    }

    public void Playin()
    {
        playing = true;
    }
}
