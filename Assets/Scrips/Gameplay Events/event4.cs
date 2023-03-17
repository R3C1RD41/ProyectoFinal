using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event4 : MonoBehaviour
{
    public GameEvent evento4;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            evento4.Raise();
            Destroy(this.gameObject);
        }    
    }
}
