using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemInfo
{
    public string UID = string.Empty;
    public int Type { get; set; }
    public string  Name { get; set; }
    public int Grade { get; set; }
    public int Level { get; set; }
    public string Prefab { get; set; }
}
public class ItemScript : MonoBehaviour
{
    public Text name_txt;
    public Text level_txt;
    public Text grade_txt;
    public Image icon_img;
    public Button ok_btn;

    public ItemInfo itemInfo = new ItemInfo();

    public Action<string> callback;

    public void Setup(string _uid, ItemInfo _itemInfo, Action<string> _act)
    {
        itemInfo.UID = _uid;
        itemInfo.Name = _itemInfo.Name;
        itemInfo.Grade = _itemInfo.Grade;
        itemInfo.Level = _itemInfo.Level;
        itemInfo.Prefab = _itemInfo.Prefab;
        callback = _act;

        ok_btn.onClick.AddListener(OnClick);
        Display();
    }

    public void Display()
    {
        name_txt.text = itemInfo.Name;
        level_txt.text = "" + itemInfo.Level;
        icon_img.sprite = Resources.Load<Sprite>(itemInfo.Prefab);
    }

    void OnClick()
    {
        callback(itemInfo.UID);
    }


}
