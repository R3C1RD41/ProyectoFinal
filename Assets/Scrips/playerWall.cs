using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWall : MonoBehaviour
{
    public PlayerDataSO playerData;
    public float wallLife;

    private void Start()
    {
        wallLife = playerData.wallLife;
    }

    public void damage(float da�o)
    {
        wallLife -= da�o;
        if(wallLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
