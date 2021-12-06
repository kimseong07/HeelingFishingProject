using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public GameObject mainFish;

    public bool onFish = false;

    public int curFishHp = 0;
    public int maxFishHp = 0;
    public int damage = 0;

    PlayerMove player;
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(curFishHp <= 0)
        {
            DestroyFish();
        }
    }

    public void DestroyFish()
    {
         if (onFish)
         {
            curFishHp = maxFishHp;
            mainFish.SetActive(false);
         }
    }
}
