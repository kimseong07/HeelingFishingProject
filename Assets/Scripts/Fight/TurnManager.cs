using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    static TurnManager _instance;
    public static TurnManager Instance { get { return _instance; } }

    LakeScritpts lake;

    public bool playerTurn = false;

    public Button attackBtn;

    public PlayerMove player;

    // Start is called before the first frame update
    void Start()
    {
        lake = FindObjectOfType<LakeScritpts>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn)
        {
            attackBtn.interactable = false;
        }
        else if (!playerTurn)
        {
            attackBtn.interactable = true;
        }
    }

    public void Attack()
    {
        lake.instFishList[0].GetComponent<FishScript>().curFishHp -= player.playerDamage;
    }
}
