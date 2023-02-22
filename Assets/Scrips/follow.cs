using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    private Rigidbody objetc;
    public Rigidbody seguir;
    private Vector3 posicion; 
    // Start is called before the first frame update
    void Start()
    {
        objetc = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //posicion = Vector3.zero;
        //posicion.x = seguir.position.x;
        //posicion.y = seguir.position.z;
        objetc.position = seguir.position;
    }
}
