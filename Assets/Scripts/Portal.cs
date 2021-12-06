using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject vcam;

    public float vcamX;
    public float vcamY;

    void Start()
    {

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
