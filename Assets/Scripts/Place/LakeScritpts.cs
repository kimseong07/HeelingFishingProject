using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeScritpts : MonoBehaviour
{
    Fishing fishing;
    FishScript fishBase;
    public Transform player;
    public Transform fishingfloatPos;

    public List<GameObject> fishList = new List<GameObject>();

    public SpriteRenderer fishSprite;

    private float instanceFishTime = 0.5f;

    private int fishNum = 0;

    private int curFishHp = 0;

    private void FixedUpdate()
    {
        if (instanceFishTime >= 0)
        {
            instanceFishTime = instanceFishTime - Time.deltaTime;
        }
    }

    private void Awake()
    {
        fishing = FindObjectOfType<Fishing>();
        fishBase = FindObjectOfType<FishScript>();
    }

    void Update()
    {
        if (fishing.isFishing)
        {
            Imgfish();

            if (fishList[fishNum].GetComponent<FishScript>().curFishHp <= 0)
            {
                Debug.Log(fishNum);

                if (instanceFishTime <= 0)
                {
                    Instantiate(fishList[fishNum], fishingfloatPos.position, Quaternion.identity);

                    instanceFishTime = 0.5f;
                }

                Fishing.instance.UnsetPanel();
            }
        }
    }

    public void Imgfish()
    {
        if (fishing.fishCount < 1)
        {
            fishNum = Random.Range(0, fishList.Count);
            fishing.fishCount++;
            Debug.Log("Áõ°¡");
        }

        fishSprite.sprite = fishList[fishNum].GetComponent<SpriteRenderer>().sprite;
    }
}
