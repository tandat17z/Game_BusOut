using System.Collections;
using System.Collections.Generic;
using SinuousProductions;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> allCards = new();
    private int currentIndex = 0;

    private void Start()
    {
        Card[] cards = Resources.LoadAll<Card>("Cards");
        allCards.AddRange(cards);

        HandManager hand = FindObjectOfType<HandManager>();
        for(int i = 0; i < 6; i++)
        {
            DrawCard(hand);
        }
    }

    public void DrawCard(HandManager handManager)
    {
        if( allCards.Count == 0)
        {
            return;
        }

        Card nextCard = allCards[currentIndex];
        handManager.AddCardToHand(nextCard);
        currentIndex = (currentIndex + 1) % allCards.Count;
    }

}
