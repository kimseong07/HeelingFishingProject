using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 4f;
    public SpriteRenderer playerSprite;
    Rigidbody2D rigid2D;

    CameraMove cam;

    public Vector3 moveVelocity;

    public float playerTime = 0f;

    public GameObject Inventory;
    bool isOpenInventory;
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<CameraMove>();

        isOpenInventory = false;
    }

    void Update()
    {
        Move();
        //OpenBook();
    }

    void Move()
    {
        moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
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

    void OpenBook()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpenInventory)
            {
                Inventory.SetActive(true);
                isOpenInventory = true;
            }
            else if (isOpenInventory)
            {
                Inventory.SetActive(false);
                isOpenInventory = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Potal")
        {
            cam.fade = true;
        }
    }
}