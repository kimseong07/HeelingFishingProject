using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "AfterSchool/CardGame/Card")]
public class Card : ScriptableObject
{
    public string id;
    public string tagString;
    public string tagString2;

    public bool usable;
    public bool disposable;

    public CardPower power;

    public void Init(string id, string tagString, string tagString2, CardPower defaultCP, bool dispose = false, bool usable = true)
    {
        this.id = id;
        this.tagString = tagString;
        this.tagString2 = tagString2;
        this.disposable = dispose;

        power = defaultCP;
    }

    public Card Clone(bool setDispose = false)
    {
        var card = CreateInstance<Card>();
        bool dispose = setDispose || this.disposable;
        card.Init(id, tagString, tagString2, power, dispose);
        return card;
    }
}
