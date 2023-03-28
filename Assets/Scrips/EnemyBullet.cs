using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameEvent damagePlayer;
    public EnemyData enemyData;
    public GameObject wall;
    public playerWall playerWallSC;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damagePlayer.Raise();

        }
        if (collision.gameObject.CompareTag("PlayerWall"))
        {
            wall = collision.gameObject;
            playerWallSC = wall.GetComponentInParent(typeof(playerWall)) as playerWall;
            playerWallSC.damage(enemyData.damage);
        }
        Destroy(this.gameObject);
    }
}
