using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public bossData boss;
    public PlayerDataSO player;
    public Animator bossAnimator;
    public GameEvent explosion;
    private bool mitadDa�o;

    private void Start()
    {
        mitadDa�o = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            boss.puertas -= player.damage;

            if(boss.puertas <= 10 && mitadDa�o == false)
            {
                bossAnimator.SetTrigger("da�o 3");
                mitadDa�o = true;
                explosion.Raise();
            }
            if (boss.puertas <= 0)
            {
                bossAnimator.SetTrigger("da�o 4");
                explosion.Raise();
                Destroy(this.gameObject);
            }
        }
    }
}
