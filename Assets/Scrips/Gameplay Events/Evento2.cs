using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento2 : MonoBehaviour
{
    public GameEvent event2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            event2.Raise();
            Destroy(this.gameObject);
        }
        
    }
}
