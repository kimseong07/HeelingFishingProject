using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class CanvasMoveManager : MonoBehaviour
{
    private static CanvasMoveManager _instance;
    public static CanvasMoveManager Instance { get { return _instance; } }

    public Transform InventoryPanel;

    public bool isOpenInventory;

    public float moveYDownPos = 360;
    public float moveYUpPos = 1080;
    public float time = 1;

    private void Awake()
    {
        _instance = this;
    }
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
