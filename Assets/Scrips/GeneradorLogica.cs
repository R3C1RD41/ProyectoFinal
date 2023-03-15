using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorLogica : MonoBehaviour
{
    public float life;
    public GameEvent escudo;
    public PlayerDataSO playerData;
    public GameObject particulas;
    public GameObject tmpParticulas;
    public Transform position;

    private void Start()
    {
        life = 20f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            life -= playerData.damage;
            if(life <= 0)
            {
                tmpParticulas = Instantiate(particulas, position.position, Quaternion.identity);
                //tmpParticulas.transform.up = position.up;
                escudo.Raise();
                Destroy(this.gameObject);
            }
        }
    }
}
