using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatalWalls : MonoBehaviour
{
    public GameEvent bulletWall;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("enemyBullet"))
        {
            bulletWall.Raise();
        }
    }
}
