using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody player;
    private Vector3 movement;
    private float yVel;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        yVel = player.velocity.y;
        transform.Translate(Vector3.forward * speed * Time.deltaTime
            * -Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * speed * Time.deltaTime
            * -Input.GetAxis("Horizontal"));
        movement.y = yVel;
        player.velocity = movement;
    }
}
