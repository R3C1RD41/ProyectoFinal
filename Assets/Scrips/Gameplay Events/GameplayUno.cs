using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUno : MonoBehaviour
{
    public GameEvent event1;

    private void OnTriggerEnter(Collider other)
    {
        event1.Raise();
        Destroy(this.gameObject);
    }
}
