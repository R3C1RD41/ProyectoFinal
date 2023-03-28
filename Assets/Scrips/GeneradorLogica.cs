using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneradorLogica : MonoBehaviour
{
    public float life;
    public GameEvent escudo;
    public PlayerDataSO playerData;
    public GameObject particulas;
    public GameObject tmpParticulas;
    public Transform position;
    public Image lifeImage;

    private void Start()
    {
        life = 10f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            life -= playerData.damage;
            lifeImage.fillAmount = life * 0.1f;
            if(life <= 0)
            {
                tmpParticulas = Instantiate(particulas, position.position, Quaternion.identity);
                escudo.Raise();
                Destroy(this.gameObject);
            }
        }
    }
}
