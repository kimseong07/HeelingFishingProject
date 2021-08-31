using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private PlayerMove player;

    public GameObject vcam;

    public float vcamX;
    public float vcamY;
    public float playerX;
    public float playerY;
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            vcam.transform.position = new Vector3(vcamX, vcamY, -20);
        }
    }
}
