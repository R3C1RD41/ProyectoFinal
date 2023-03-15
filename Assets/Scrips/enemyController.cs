using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    private States StateActual;
    public GameEvent enemyFire;
    public GameEvent enemyDead;
    public float life;
    public float speed;
    public float bulletForce;
    public float launchTime;
    public float deadTime;
    public Animator EnemyAnimator;
    public GameObject bullet;
    private GameObject tmpBullet;
    public GameObject lifeLoot;
    private GameObject tmpLifeLoot;
    public Transform player;
    public Transform bulletPoint;
    public PlayerDataSO playerData;
    private bool attack;
    private bool dead;
    private int loot;

    // Start is called before the first frame update
    void Start()
    {
        life = 1;
        loot = Random.Range(0, 2);
        enemyAgent = GetComponent<NavMeshAgent>();
        attack = false;
        dead = false;
        EnemyAnimator = GetComponentInChildren(typeof(Animator)) as Animator;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //EnemyAnimator = this.GetComponent<Animator>();
        StateActual = States.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        switch(StateActual)
        {
            case States.IDLE:
                enemyAgent.SetDestination(player.position);
                if (Vector3.Distance(this.transform.position,player.position) < 10f)
                {
                    StateActual = States.ATTACK;
                    attack = true;
                }
                break;
            case States.MOVE:
                enemyAgent.SetDestination(player.position);
                this.transform.LookAt(player);
                if (Vector3.Distance(this.transform.position, player.position) < 10f)
                {
                    attack = true;
                    StateActual = States.ATTACK;
                }
                break;
            case States.ATTACK:
                enemyAgent.SetDestination(player.position);
                this.transform.LookAt(player);
                if (attack)
                {
                    StartCoroutine("fire");
                    attack = false;
                }
                if (!attack && Vector3.Distance(this.transform.position, player.position) > 15f)
                {
                    StopCoroutine("fire");
                    StateActual = States.MOVE;
                }   
                break;
            case States.DEAD:
                if (!dead)
                {
                    StopCoroutine("fire");
                    StartCoroutine("muerte");
                    dead = true;
                }
                break;
        }
        //enemyAgent.SetDestination(player.position);
        EnemyAnimator.SetFloat("camina", enemyAgent.velocity.sqrMagnitude);
    }

    IEnumerator fire()
    {
        yield return new WaitForSeconds(launchTime);
        EnemyAnimator.SetTrigger("dispara");
          tmpBullet = Instantiate(bullet,
                                      bulletPoint.position,
                                      Quaternion.identity);
          tmpBullet.transform.up = bulletPoint.forward;

          tmpBullet.GetComponent<Rigidbody>().AddForce(
              bulletPoint.forward * bulletForce,
              ForceMode.VelocityChange
              );
        StartCoroutine("fire");
        enemyFire.Raise();
    }

    IEnumerator muerte()
    {
        EnemyAnimator.SetTrigger("muerte");
        enemyDead.Raise();
        yield return new WaitForSeconds(deadTime);
        if(loot == 0)
        {
            tmpLifeLoot = Instantiate(lifeLoot, this.transform.position,Quaternion.identity);
            //tmpLifeLoot.transform.up = -this.transform.right;
            tmpLifeLoot.transform.rotation = Quaternion.Euler(270,45,0);
        }
        Destroy(this.gameObject);
    }

    public void damage()
    {
        life -= playerData.damage;

        if(life <= 0)
        {
            StateActual = States.DEAD;
        }
    }
}
public enum States
{
    IDLE,
    ATTACK,
    MOVE,
    DEAD
}