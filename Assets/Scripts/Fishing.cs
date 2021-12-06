using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : BaseFishingScript
{
    public static Fishing instance;

    public GameObject floatPos;
    PlayerMove player;
    //Reel reel;

    public float time = 0f;
    public int randf = 0;
    public int randc = 0;

    public GameObject mainArea;
    public GameObject fightArea;

    public SpriteRenderer signal;
    //public Image gauge;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("다수의 Fishing이 실행중입니다");
        }
        instance = this;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        //reel = FindObjectOfType<Reel>();

        fishing = false;
        cfishing = false;
        isBite = true;

        randc = 1;
        randf = 0;
        //length = 0.1f;
    }

    void Update()
    {
        ReadyFishing();

        StartFishing();
    }

    public void ReadyFishing()
    {
        if (cfishing && Input.GetKeyDown(KeyCode.Space) && isBite)
        {
            if (fishing)
            {
                OnFishing();
            }
            else if (!fishing)
            {
                DownFishing();
            }
        }
    }

    public void OnFishing()
    {
        player.playerSpeed = 4f;
        signal.gameObject.SetActive(false);
        signal.color = new Color(0, 0, 0, 0);

        randc = 1;
        randf = 0;

        player.SetFhishingfloat(floatPos.gameObject.transform);

        fishing = false;
    }

    public void DownFishing()
    {
        player.playerSpeed = 0f;
        signal.gameObject.SetActive(true);

        player.Fhishingfloat();

        fishing = true;
    }

    public void StartFishing()
    {
        if (fishing)
        {
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

                isBite = false;
            }
            else
            {
                signal.color = Color.green;
            }

            if (randf == randc && Input.GetKeyDown(KeyCode.Space) && !isBite)
            {
                SetPanel();

                time = 5f;

                isFishing = true;

                isBite = true;
            }
        }
    }


    public void SetPanel()
    {
        fightArea.SetActive(true);
        mainArea.SetActive(false);
    }

    public void UnsetPanel()
    {
        time = 0f;
        randc = 1;
        randf = 0;
        fishCount = 0;

        fightArea.SetActive(false);
        mainArea.SetActive(true);
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
