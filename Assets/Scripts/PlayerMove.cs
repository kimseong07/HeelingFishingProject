using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private static PlayerMove _instance;
    public static PlayerMove Instance
    {
        get { return _instance; }
    }

    public float playerSpeed = 4f;
    public int playerHP = 0;
    public int playerDamage = 0;

    CameraMove cam;

    public Vector3 moveVelocity;

    public float playerTime = 0f;

    public GameObject fishingFloat;
    public float throwPower;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        cam = FindObjectOfType<CameraMove>();

    }

    private void FixedUpdate()
    {
        Vector2 maxTrn = new Vector2(fishingFloat.transform.position.x, this.transform.position.y);

        if (fishingFloat.transform.position.y <= this.transform.position.y)
        {
            fishingFloat.transform.position = maxTrn;
            fishingFloat.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void Update()
    {
        Move();
        if (!Fishing.instance.fishing)
        {
            fishingFloat.transform.position = new Vector2(Fishing.instance.floatPos.transform.position.x, Fishing.instance.floatPos.transform.position.y);
        }

        if(playerHP <= 0)
        {
            //UI²ô°í ³¬½Ã ½ÇÆÐ
        }
    }

    void Move()
    {
        moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0 && !Fishing.instance.fishing)
        {
            moveVelocity = Vector3.left;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if(Input.GetAxisRaw("Horizontal") > 0 && !Fishing.instance.fishing)
        {
            moveVelocity = Vector3.left * -1;
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if(Input.GetAxisRaw("Vertical") > 0 && !Fishing.instance.fishing)
        {
            moveVelocity = Vector3.up;
        }
        else if(Input.GetAxisRaw("Vertical") < 0 && !Fishing.instance.fishing)
        {
            moveVelocity = Vector3.down;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 8;
        }
        else
        {
            playerSpeed = 4;
        }

        transform.position += moveVelocity * playerSpeed * Time.deltaTime;
    }

    public void Fhishingfloat()
    {
        Vector2 power = new Vector2(0, throwPower);
        fishingFloat.GetComponent<Rigidbody2D>().gravityScale = 1;
        fishingFloat.GetComponent<Rigidbody2D>().AddForce(power, ForceMode2D.Impulse);
        Debug.Log(this.gameObject.transform.rotation.y);
        if (this.gameObject.transform.eulerAngles.y == 180f)
        {
            fishingFloat.GetComponent<Rigidbody2D>().AddForce(Vector2.left * -1 * throwPower * 30f);
        }
        else if(this.gameObject.transform.eulerAngles.y == 0f)
        {
            fishingFloat.GetComponent<Rigidbody2D>().AddForce(Vector2.left * throwPower * 30f );
        }
    }

    public void SetFhishingfloat(Transform circle)
    {
        fishingFloat.GetComponent<Rigidbody2D>().gravityScale = 0;
        fishingFloat.transform.position = new Vector2(circle.position.x, circle.position.y);
        fishingFloat.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Potal")
        {
            cam.fade = true;
        }
    }
}