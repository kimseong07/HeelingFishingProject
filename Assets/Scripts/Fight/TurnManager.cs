using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    static TurnManager _instance;
    public static TurnManager Instance { get { return _instance; } }

    public bool playerTurn = false;

    public Button attackBtn;

    public PlayerMove player;

    public GameObject startScene;
    public GameObject mainScene;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

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
        LakeScritpts.Instance.instFishList[0].GetComponent<FishScript>().curFishHp -= player.playerDamage;
    }
    public void StartBtn()
    {
        startScene.SetActive(false);
        mainScene.SetActive(true);
    }

    public void EndBtn()
    {
        Application.Quit();
    }
}
