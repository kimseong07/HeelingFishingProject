using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    PlayerMove player;
    Reel reel;

    public bool cfishing;
    public bool fishing;

    public float time = 0f;
    public int randf = 0;
    public int randc = 0;

    public float length = 0f;

    public GameObject panel;
    public SpriteRenderer signal;

    public Text text;
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        reel = FindObjectOfType<Reel>();

        fishing = false;
        cfishing = false;
        randc = 1;
        randf = 0;
    }

    void Update()
    {
        if (cfishing && Input.GetKeyDown(KeyCode.Space))
        {
            if (fishing)
            {
                player.playerSpeed = 4f;
                signal.gameObject.SetActive(false);
                fishing = false;
            }
            else if (!fishing)
            {
                player.playerSpeed = 0f;
                signal.gameObject.SetActive(true);
                fishing = true;
            }
        }

        if (fishing)
        {
            if (time < 5)
            {
                time += Time.deltaTime;
            }

            if(time >= 3f && time < 5f)
            {
                randf = Random.Range(0, 4);
                randc = Random.Range(0, 4);
                time = 0f;
            }

            if(randc == randf)
            {
                signal.color = Color.red;
            }
            else
            {
                signal.color = Color.green;
            }

            if(randf == randc && Input.GetMouseButton(0))
            {
                Afhishing();
                time = 5f;
            }
        }

    }

    public void Afhishing()
    {
        panel.SetActive(true);
        length += Time.deltaTime;

        if(reel.wheelAngle >= 360)
        {

        }
    }
    public void Efhishing()
    {
        panel.SetActive(false);
        time = 0f;
        randc = 1;
        randf = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cfishing = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cfishing = false;
    }
}
