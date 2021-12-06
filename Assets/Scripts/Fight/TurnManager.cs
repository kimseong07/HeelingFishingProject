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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if(playerTurn)
        {
            attackBtn.interactable = true;
        }
        else if(!playerTurn)
        {
            attackBtn.interactable = false;
        }
    }
}
