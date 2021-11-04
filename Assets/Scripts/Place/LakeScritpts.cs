using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeScritpts : MonoBehaviour
{
    Fishing fishing;
    public Transform player;
    public Transform fishingfloatPos;

    public List<GameObject> fishList = new List<GameObject>();

    private float instanceFishTime = 0.5f;

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
    }

    void Update()
    {
        if (fishing.length <= 0)
        {
            int fishNum = Random.Range(0, fishList.Count);
            Debug.Log(fishNum);

            if (instanceFishTime <= 0)
            {
                Instantiate(fishList[fishNum], fishingfloatPos.position, Quaternion.identity);

                instanceFishTime = 0.5f;
            }

            if (fishing.length <= 0)
            {
                fishing.length = 0.1f;
            }

            Fishing.instance.UnsetPanel();
        }
    }
}
