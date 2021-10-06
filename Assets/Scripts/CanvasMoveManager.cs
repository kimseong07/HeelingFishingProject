using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CanvasMoveManager : MonoBehaviour
{

    public Transform InventoryPanel;
    public bool isOpenInventory;

    public float moveYDownPos = 360;
    public float moveYUpPos = 1080;
    public float time = 1;

    // Start is called before the first frame update
    void Start()
    {
        isOpenInventory = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenBook();
    }

    void OpenBook()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isOpenInventory)
            {
                InventoryPanel.DOMoveY( moveYDownPos, time);

                isOpenInventory = true;
            }
            else if (isOpenInventory)
            {
                InventoryPanel.DOMoveY( moveYUpPos , time);

                isOpenInventory = false;
            }
        }
    }
}
