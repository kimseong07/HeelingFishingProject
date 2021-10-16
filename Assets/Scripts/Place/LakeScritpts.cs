using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeScritpts : MonoBehaviour
{
    Fishing fishing;
    public Transform player;

    public List<GameObject> fishList = new List<GameObject>();


    private void Awake()
    {
        fishing = FindObjectOfType<Fishing>();
    }

    void Update()
    {
        SpawnFish();
    }
    public void SpawnFish()
    {
        if (fishing.length <= 0)
        {
            if (fishing.fishCount < 1)
            {
                int fishNum = Random.Range(0, fishList.Count + 1);

                fishing.fishCount++;
            }
        }
    }
}
