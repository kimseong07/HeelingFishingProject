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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fishing.length <= 0)
        {
            if (fishing.fishCount < 1)
            {
                int fishNum = Random.Range(0, fishList.Count + 1);
                Instantiate(fishList[fishNum], player);
                fishing.fishCount++;
            }
        }
    }
}
