using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evento3 : MonoBehaviour
{
    public GameEvent event3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            event3.Raise();
            Destroy(this.gameObject);
        }
    }
}
