using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invento : MonoBehaviour
{
    private static Invento _instance;
    public static Invento Instance
    {
        get { return _instance; }
    }

    public GameObject ItemPrefab;
    public GameObject Root;

    public List<ItemScript> ItemList = new List<ItemScript>();//아이템 목록(실제)
    public List<ItemInfo> ItemInfoList = new List<ItemInfo>();//보유(보이는)
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        //ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "BluefaceAngelfish", Grade = 1, Level = 5, Prefab = "Sprites/BluefaceAngelfish" });
        //ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "Silago", Grade = 1, Level = 4, Prefab = "Sprites/Silago" });
        //ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "Clownfish", Grade = 1, Level = 4, Prefab = "Sprites/Clownfish" });
        //ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "BlueTang", Grade = 1, Level = 3, Prefab = "Sprites/BlueTang" });
        //ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "BlueTang", Grade = 1, Level = 3, Prefab = "Sprites/BlueTang" });
        //ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "Clownfish", Grade = 1, Level = 5, Prefab = "Sprites/Clownfish" });

        Refresh();
        foreach (var item in ItemInfoList)
        {
            AddItem(item);
        }
    }

    public ItemScript AddItem(ItemInfo iteminfo)
    {
        GameObject go = Instantiate(ItemPrefab);
        go.transform.SetParent(Root.transform);
        ItemScript item = go.GetComponent<ItemScript>();
        item.Setup(Guid.NewGuid().ToString(), iteminfo, Callback);
        ItemList.Add(item);
        return item;
    }    

    void Callback(string uid)
    {
        print(uid);
        ItemScript item = FindItem(uid);
        RemoveItem(item);
    }

    void RemoveItem(ItemScript item)
    {
        ItemList.Remove(item);
        Destroy(item.gameObject);
    }

    ItemScript FindItem(string _uid)
    {
        ItemScript item = ItemList.Find(a => a.itemInfo.UID == _uid);
        return item;
    }

    public void Sort(int sortm)
    {
        if (sortm == 1) ItemInfoList.Sort((a, b) => a.Level.CompareTo(b.Level));
        if (sortm == 2) ItemInfoList.Sort(CompareName);
    }

    int CompareName(object x, object y)
    {
        ItemInfo a = x as ItemInfo;
        ItemInfo b = y as ItemInfo;
        return a.Name.CompareTo(b.Name);
    }

    public void Refresh()
    {
        RemoveAll();
        foreach (var item in ItemInfoList)
        {
            AddItem(item);
        }
    }

    public void RemoveAll()
    {
        ItemList.RemoveAll(a => a != null);
        DeleteRootChilds();
    }

    public void DeleteRootChilds()
    {
        var child = Root.GetComponentsInChildren<ItemScript>();
        foreach (var item in child)
        {
            if(item != this.transform)
            {
                Destroy(item.gameObject);  
            }
        }
    }
}
