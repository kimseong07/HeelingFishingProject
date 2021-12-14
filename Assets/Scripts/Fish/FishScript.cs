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

    public bool onPlayer = false;
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

        if (Input.GetKeyDown(KeyCode.E) && onPlayer)
        {
            Invento.Instance.ItemInfoList.Add(new ItemInfo() { Type = 1, Name = this.gameObject.GetComponent<SpriteRenderer>().sprite.name.ToString(), 
                Grade = Random.Range(1,5), Level = Random.Range(1, 5), Prefab = "Sprites/" + this.gameObject.GetComponent<SpriteRenderer>().sprite.name.ToString() });
            //Invento.Instance.ItemInfoList.Add(new ItemInfo() { Type = 1, Name = "BluefaceAngelfish", Grade = 1, Level = 5, Prefab = "Sprites/BluefaceAngelfish" });
            this.gameObject.SetActive(false);

            Invento.Instance.Refresh();
            //foreach (var item in Invento.Instance.ItemInfoList)
            //{
            //    Invento.Instance.AddItem(item);
            //}
            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            onPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            onPlayer = false;
        }
    }
}
