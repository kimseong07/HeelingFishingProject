using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 4f;

    CameraMove cam;

    public Vector3 moveVelocity;

    public float playerTime = 0f;

    public GameObject fhishingFloat;
    public float throwPower;

    void Start()
    {
        cam = FindObjectOfType<CameraMove>();

    }

    private void FixedUpdate()
    {
        Vector2 maxTrn = new Vector2(fhishingFloat.transform.position.x, this.transform.position.y);

        if (fhishingFloat.transform.position.y <= this.transform.position.y)
        {
            fhishingFloat.transform.position = maxTrn;
            fhishingFloat.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
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

    public void Fhishingfloat()
    {
        Vector2 power = new Vector2(0, throwPower);
        fhishingFloat.GetComponent<Rigidbody2D>().gravityScale = 1;
        fhishingFloat.GetComponent<Rigidbody2D>().AddForce(power, ForceMode2D.Impulse);
        fhishingFloat.GetComponent<Rigidbody2D>().AddForce(Vector2.right * throwPower * 30f);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Potal")
        {
            cam.fade = true;
        }
    }
}