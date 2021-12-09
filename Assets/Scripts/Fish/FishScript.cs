using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishScript : MonoBehaviour
{
    public GameObject mainFish;

    public float curFishHp = 10;
    public float maxFishHp = 10;
    public int damage = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(curFishHp <= 0)
        {
            curFishHp = maxFishHp;
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                //LakeScritpts.Instance.instFishList.Clear();
            }
        }
    }
}
