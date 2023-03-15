using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
    private float life;
    public GameEvent lifeItem;
    public PlayerDataSO playerData;

    void Start()
    {
        life = Random.Range(0.01f, 0.06f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerData.valueLife += life;
            if(playerData.valueLife > 1)
            {
                playerData.valueLife = 1;
            }
            lifeItem.Raise();
            Destroy(this.gameObject);
        }
    }
}
