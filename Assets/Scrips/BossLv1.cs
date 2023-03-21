using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLv1 : MonoBehaviour
{
    public float bulletForce;
    public GameObject boss;
    public GameObject bossBulet;
    public GameObject tmpBossBulet;
    public GameObject tmpBossBulet2;
    public bossData bosslife;
    public Image torretaIzq;
    public Image Puertas;
    public Image torretaDer;
    public GameEvent torretaSound;
    public GameEvent win;
    private bool torretaSoundCond;
    private bool defeated;
    private Animator bossAnimator;
    public Transform[] fire;
    void Start()
    {
        torretaSoundCond = true;
        defeated = false;
        bosslife.torreta1 = 20f;
        bosslife.puertas = 20f;
        bosslife.torreta2 = 20f;
        bossAnimator = GetComponent<Animator>();
        StartCoroutine("attack");
    }

    void Update()
    {
        torretaDer.fillAmount = bosslife.torreta2 * 0.05f;
        torretaIzq.fillAmount = bosslife.torreta1 * 0.05f;
        Puertas.fillAmount = bosslife.puertas * 0.05f;
        if (bossAnimator.GetCurrentAnimatorStateInfo(0).IsName("Movimiento"))
        {
            StartCoroutine("fireAttack");
        }
        else
        {
            torretaSoundCond = true;
            StopCoroutine("fireAttack");
        }

        if(bosslife.torreta1 <= 0 && bosslife.torreta2 <= 0 && bosslife.puertas <= 0 && defeated == false)
        {
            defeated = true;
            win.Raise();
            Time.timeScale = 0;
        }
        if (bosslife.torreta1 <= 0 && bosslife.torreta2 <= 0 && bosslife.puertas <= 0)
        {
            Time.timeScale = 0;
        }
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(10f);
        bossAnimator.SetTrigger("movimiento");
        StartCoroutine("attack");
    }

    IEnumerator fireAttack()
    {
        yield return new WaitForSeconds(0.05f);
        if (bosslife.torreta1>0)
        {
            tmpBossBulet = Instantiate(bossBulet,
                                      fire[0].position,
                                      Quaternion.identity);
            tmpBossBulet.transform.up = fire[0].forward;

            tmpBossBulet.GetComponent<Rigidbody>().AddForce(
                fire[0].forward * bulletForce,
                ForceMode.VelocityChange
                );
        }

        if (bosslife.torreta2 > 0)
        {
            tmpBossBulet2 = Instantiate(bossBulet,
                                      fire[1].position,
                                      Quaternion.identity);
            tmpBossBulet2.transform.up = fire[1].forward;

            tmpBossBulet2.GetComponent<Rigidbody>().AddForce(
                fire[1].forward * bulletForce,
                ForceMode.VelocityChange
                );
        }

        if (bosslife.torreta2 > 0 && torretaSoundCond || bosslife.torreta1 > 0 && torretaSoundCond)
        {
            torretaSound.Raise();
            torretaSoundCond = false;
        }
    }
}
