using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody player;
    public Animator playerAnimator;
    public Collider playerCollider;
    public GameObject playerPavo;
    public LayerMask LayerPlayer;
    public LayerMask LayerInvencible;
    private Vector3 movement;
    private float yVel;
    public PlayerDataSO playerData;
    void Start()
    {
        player = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        playerAnimator = GetComponent<Animator>();
        playerPavo = player.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        if (playerData.playing)
        {
            //Movimiento
            //yVel = player.velocity.y;
            //transform.Translate(Vector3.forward * speed * Time.deltaTime
            //    * -Input.GetAxis("Vertical"));
            //transform.Translate(Vector3.right * speed * Time.deltaTime
            //    * -Input.GetAxis("Horizontal"));
            //movement.x = -Input.GetAxis("Horizontal");
            //movement.z = -Input.GetAxis("Vertical");
            //Debug.Log("Movimiento :" + movement);
            //movement.y = yVel;
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
                player.velocity = new Vector3(0, 0, 0);
            }
            //Acciones

            ////Esquiva
            
            //Move(movement);
        }  
    }

    protected void FixedUpdate()
    {
        Move(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("rodar"))
            {
                playerAnimator.SetTrigger("rodar");
                player.AddForce(
                        player.transform.right * 6,
                        ForceMode.Impulse
                        );
                playerPavo.layer = LayerMask.NameToLayer("invencible");
                StartCoroutine("dash");
            }
            //player.velocity = new Vector3(0, 0, 0);
            //playerOrientation.AddForce(playerOrientation.transform.right ,ForceMode.Force);
            //playerOrientation.transform.Translate(Vector3.right * speed * 6 * Time.deltaTime);
        }
    }

    private void Move(Vector3 direction)
    {
        //transform.position += direction.normalized * speed * Time.deltaTime;
        //player.MovePosition(player.position + direction.normalized * speed * Time.fixedDeltaTime);
        //player.AddForce(direction.normalized * speed, ForceMode.Acceleration);
        player.AddForce(direction.normalized * speed ,ForceMode.Acceleration);
        
        //player.SimpleMove(direction.normalized * speed);
    }

    public void gameOver()
    {
        if (!playerData.gameOver)
        {
            playerData.playing = false;
            playerAnimator.SetTrigger("dead");
            playerPavo.layer = LayerMask.NameToLayer("invencible");
            playerData.gameOver = true;
        }
    }

    public void muerteVida()
    {

    }
    IEnumerator dash()
    {
        yield return new WaitForSeconds(0.5f);
        playerPavo.layer = LayerMask.NameToLayer("Player");
    }
}
