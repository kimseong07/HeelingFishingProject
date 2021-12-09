using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LakeScritpts : MonoBehaviour
{
    private static LakeScritpts _instance;
    public static LakeScritpts Instance { get { return _instance; } }

    public Transform player;
    public Transform fishingfloatPos;

    public List<GameObject> fishList = new List<GameObject>();

    public List<GameObject> instFishList = new List<GameObject>();

    public SpriteRenderer fishSprite;

    public GameObject fishHpBar;

    private float instanceFishTime = 0.5f;

    private int fishNum = 0;

    private int instfish = 0;
    private void FixedUpdate()
    {
        if (instanceFishTime >= 0)
        {
            instanceFishTime = instanceFishTime - Time.deltaTime;
        }
    }

    private void Awake()
    {

    }

    void Update()
    {
        if (Fishing.instance.isFishing)
        {
            Imgfish();
            FishHp();

            if (instFishList[0].GetComponent<FishScript>().curFishHp <= 0)
            {
                if (instfish < 1)
                {
                    if (instanceFishTime <= 0)
                    {
                        Instantiate(fishList[fishNum], fishingfloatPos.position, Quaternion.identity);

                        instanceFishTime = 0.5f;

                        instfish++;
                    }
                }

                Fishing.instance.UnsetPanel();
            }
        }
    }

    public void Imgfish()
    {
        if (Fishing.instance.fishCount < 1)
        {
            fishNum = Random.Range(0, fishList.Count);
            if (instanceFishTime <= 0)
            {
                GameObject fishobj = Instantiate(fishList[fishNum], fishSprite.transform.position, Quaternion.identity);

                instFishList.Add(fishobj);

                instanceFishTime = 0.5f;
            }

            Fishing.instance.fishCount++;
        }
    }

    public void FishHp()
    {
        fishHpBar.GetComponent<Image>().fillAmount = Mathf.Lerp(fishHpBar.GetComponent<Image>().fillAmount, 
            instFishList[0].GetComponent<FishScript>().curFishHp
            / instFishList[0].GetComponent<FishScript>().maxFishHp, Time.deltaTime * 2);
    }


}
