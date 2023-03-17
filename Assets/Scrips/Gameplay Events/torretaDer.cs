using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torretaDer : MonoBehaviour
{
    public bossData boss;
    public PlayerDataSO player;
    public Animator bossAnimator;
    public GameEvent explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            boss.torreta2 -= player.damage;

            if (boss.torreta2 <= 0)
            {
                bossAnimator.SetTrigger("daño 2");
                explosion.Raise();
                Destroy(this.gameObject);
            }
        }
    }
}
