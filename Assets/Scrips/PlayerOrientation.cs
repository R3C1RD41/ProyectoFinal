using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
    public Rigidbody player;
    //public float angle;
    public Camera mainCamara;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * Time.deltaTime
        // * Input.GetAxis("Horizontal"));
        if (!Input.GetKey(KeyCode.Mouse1))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 315, 0);
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 225, 0);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 135, 0);
            }
        }
        else
        {
            Vector3 screenPosition = mainCamara.WorldToViewportPoint(transform.position);
            Vector3 mousePosition = (Vector2)mainCamara.ScreenToViewportPoint(Input.mousePosition);
            
            Vector3 lookDireccion = mousePosition - screenPosition;
            float angle = Mathf.Atan2(lookDireccion.y, lookDireccion.x) * Mathf.Rad2Deg -180f;
            transform.rotation = Quaternion.Euler(new Vector3(0,-angle,0));
            
        }
        
    }
}
