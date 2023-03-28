using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public bossData boss;
    public PlayerDataSO player;
    public Animator bossAnimator;
    public GameEvent explosion;
    private bool mitadDaño;

    private void Start()
    {
        mitadDaño = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            boss.puertas -= player.damage;

            if(boss.puertas <= 10 && mitadDaño == false)
            {
                bossAnimator.SetTrigger("daño 3");
                mitadDaño = true;
                explosion.Raise();
            }
            if (boss.puertas <= 0)
            {
                bossAnimator.SetTrigger("daño 4");
                explosion.Raise();
                Destroy(this.gameObject);
            }
        }
    }
}
