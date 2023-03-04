using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody player;
    public Animator playerAnimator;
    private Vector3 movement;
    private float yVel;
    public PlayerDataSO playerData;
    void Start()
    {
        player = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.playing)
        {
            //Movimiento
            movement = Vector3.zero;
            yVel = player.velocity.y;
            //transform.Translate(Vector3.forward * speed * Time.deltaTime
            //    * -Input.GetAxis("Vertical"));
            //transform.Translate(Vector3.right * speed * Time.deltaTime
            //    * -Input.GetAxis("Horizontal"));
            movement.y = yVel;
            //player.velocity = movement;

            //Animaciones caminar
            if (Input.GetKey(KeyCode.W))
            {
                movement.z = -1;
                playerAnimator.SetInteger("Caminar Pistola", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movement.z = 1;
                playerAnimator.SetInteger("Caminar Pistola", 1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement.x = 1;
                playerAnimator.SetInteger("Caminar Pistola", 1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movement.x = -1;
                playerAnimator.SetInteger("Caminar Pistola", 1);
            }

            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
            {
                playerAnimator.SetInteger("Caminar Pistola", 0);
            }
            //Acciones

            ////Esquiva
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimator.SetTrigger("rodar");
                /*playerOrientation.AddForce(
                        playerOrientation.transform.right * 3,
                        ForceMode.Force
                        );*/
                //playerOrientation.AddForce(playerOrientation.transform.right * 2,ForceMode.Force);
                //playerOrientation.transform.Translate(Vector3.right * speed * 6 * Time.deltaTime);
            }
            Move(movement);
        }  
    }

    //protected void FixedUpdate()
    //{
    //    Move(movement);
    //}

    private void Move(Vector3 direction)
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
        //player.MovePosition(player.position + direction.normalized * speed * Time.fixedDeltaTime);
        //player.AddForce(direction.normalized * speed, ForceMode.Acceleration);
        //player.SimpleMove(direction.normalized * speed);
    }
}
