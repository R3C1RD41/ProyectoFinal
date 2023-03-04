using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatalWalls : MonoBehaviour
{
    public GameEvent bulletWall;
    public LayerMask bullet;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.CompareTag("PlayerBullet"));
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Debug.Log("EstoyColicionando y no estoy pendejo");
            bulletWall.Raise();
        }
    }
}
