using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject drawButton;

    public Deck initialDeck;
    public Deck playerDeck;


    public List<Cardhandler> cardsInHand;

    public Transform handle;

    public GameObject CardInform;
    public Image CardImage;
    public Text CardDescription;

    public GameObject button;


    // Start is called before the first frame update
    void Start()
    {
        playerDeck = initialDeck.Clone();
        playerDeck.Shuffle();
    }
    private void Update()
    {

    }

    public void Draw()
    {
        Card card = playerDeck.Draw();
        InstantiateCardObject(card);
        playerDeck.Shuffle();
    }

    public void InstantiateCardObject(Card cardData)
    {
        var cardObject = Instantiate(cardPrefab, handle.transform);
        cardObject.GetComponent<Cardhandler>().Init(cardData);
        cardsInHand.Add(cardObject.GetComponent<Cardhandler>());
    }
}
