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
    public bool bite;

    public float time = 0f;
    public int randf = 0;
    public int randc = 0;

    public float maxLength = 70f;
    public float length = 0f;
    public float tention = 0f;

    public float maxPull = 0.47f;
    public float pulllength = 0.2f;

    public GameObject panel;
    public SpriteRenderer signal;
    public Image gauge;

    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        reel = FindObjectOfType<Reel>();

        fishing = false;
        cfishing = false;
        bite = true;

        randc = 1;
        randf = 0;
        length = 0.1f;
    }

    void Update()
    {
        ReadyFishing();

        StartFishing();

        if (reel.wheelAngle <= -360)
        {
            length -= pulllength;

            tention += 0.03f;
                
            reel.wheelAngle = 0;
        }

        if(length <= 0)
        {
            UnsetPanel();
        }

    }

    public void ReadyFishing()
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
    }

    public void StartFishing()
    {
        if (fishing)
        {
            length += Time.deltaTime / 2f;

            tention -= Time.deltaTime / 15f;

            gauge.fillAmount = tention;

            pulllength += Time.deltaTime / 600f; 

            if(tention <= 0)
            {
                tention = 0;
            }

            if (time >= 3f && time < 5f)
            {
                randf = Random.Range(0, 4);
                randc = Random.Range(0, 4);
                time = 0f;
            }

            if (randc == randf)
            {
                signal.color = Color.red;
            }
            else
            {
                signal.color = Color.green;
            }

            if (time < 5)
            {
                time += Time.deltaTime;
            }

            if (randf == randc && Input.GetMouseButtonDown(1) && bite)
            {
                SetPanel();

                length = Random.Range(7, 40);

                pulllength = 0.15f;

                time = 5f;

                tention = 0.5f;

                bite = false;
            }

            if(randc != randf && length > maxLength - 10f)
            {
                length = 0f;
            }

            if(length >= maxLength)
            {
                UnsetPanel();
            }

            if(pulllength >= maxPull)
            {
                pulllength = 0.48f;
            }
        }
    }

    public void SetPanel()
    {
        panel.SetActive(true);
    }
    public void UnsetPanel()
    {
        panel.SetActive(false);

        time = 0f;
        randc = 1;
        randf = 0;
        pulllength = 0.3f;
        tention = 0.5f;

        bite = true;
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
