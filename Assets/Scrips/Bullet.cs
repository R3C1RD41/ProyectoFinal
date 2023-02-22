using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject decal;
    private Vector3 delay;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
