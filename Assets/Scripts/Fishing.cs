using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : BaseFishingScript
{
    public GameObject floatPos;
    public GameObject fishingFloat;
    PlayerMove player;
    Reel reel;

    public float time = 0f;
    public int randf = 0;
    public int randc = 0;

    public CanvasGroup fishingC;
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

        EndFishing();

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
                signal.color = new Color(0,0,0,0);

                player.SetFhishingfloat(floatPos.gameObject.transform);

                fishing = false;
            }
            else if (!fishing)
            {
                player.playerSpeed = 0f;
                signal.gameObject.SetActive(true);

                player.Fhishingfloat();

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

            pulllength += Time.deltaTime / 600f;

            gauge.fillAmount = tention;

            if(tention <= 0)
            {
                tention = 0;
            }

            if (time < 5)
            {
                time += Time.deltaTime;
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

            if (randf == randc && Input.GetMouseButtonDown(1) && bite)
            {
                SetPanel();

                length = Random.Range(7, 40);

                pulllength = 0.15f;

                time = 5f;

                tention = 0.5f;

                bite = false;
            }


        }
    }

    public void EndFishing()
    {
        if (length >= maxLength)
        {
            UnsetPanel();
        }

        if (randc != randf && length > maxLength - 10f)
        {
            length = 0f;
        }

        if (pulllength >= maxPull)
        {
            pulllength = 0.48f;
        }
    }


    public void SetPanel()
    {
        fishingC.alpha = 1;
    }

    public void UnsetPanel()
    {
        fishingC.alpha = 0;

        time = 0f;
        randc = 1;
        randf = 0;
        pulllength = 0.3f;
        tention = 0.5f;
        fishCount = 0;

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
