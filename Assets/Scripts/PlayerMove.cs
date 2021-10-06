using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 4f;
    public SpriteRenderer playerSprite;

    CameraMove cam;

    public Vector3 moveVelocity;

    public float playerTime = 0f;

    void Start()
    {
        cam = FindObjectOfType<CameraMove>();


    }

    void Update()
    {
        Move();

    }

    void Move()
    {
        moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if(Input.GetAxisRaw("Vertical") > 0)
        {
            moveVelocity = Vector3.up;
        }
        else if(Input.GetAxisRaw("Vertical") < 0)
        {
            moveVelocity = Vector3.down;
        }

        transform.position += moveVelocity * playerSpeed * Time.deltaTime;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Potal")
        {
            cam.fade = true;
        }
    }
}