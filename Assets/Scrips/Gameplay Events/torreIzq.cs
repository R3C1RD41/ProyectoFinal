using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torreIzq : MonoBehaviour
{
    public bossData boss;
    public PlayerDataSO player;
    public Animator bossAnimator;
    public GameEvent explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            boss.torreta1 -= player.damage;

            if(boss.torreta1 <= 0)
            {
                bossAnimator.SetTrigger("daño 1");
                explosion.Raise();
                Destroy(this.gameObject);
            }
        }


    }
}
