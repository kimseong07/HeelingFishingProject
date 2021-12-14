using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : BaseFishingScript
{
    public static Fishing instance;

    public GameObject floatPos;
    //Reel reel;

    public float time = 0f;
    public int randf = 0;
    public int randc = 0;

    public GameObject mainArea;
    public GameObject fightArea;

    public SpriteRenderer signal;
    //public Image gauge;

    public GameObject mainCam;

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
        PlayerMove.Instance.playerSpeed = 4f;
        signal.gameObject.SetActive(false);
        signal.color = new Color(0, 0, 0, 0);

        randc = 1;
        randf = 0;

        PlayerMove.Instance.SetFhishingfloat(floatPos.gameObject.transform);

        fishing = false;
    }

    public void DownFishing()
    {
        PlayerMove.Instance.playerSpeed = 0f;
        signal.gameObject.SetActive(true);

        PlayerMove.Instance.Fhishingfloat();

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
        //카메라
        mainCam.transform.position = new Vector3(0, 0, -20f);
    }

    public void UnsetPanel()
    {
        time = 0f;
        randc = 1;
        randf = 0;

        fishCount = 0;
        isFishing = false;

        isBite = true;

        OnFishing();

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
