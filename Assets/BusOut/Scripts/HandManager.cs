using System.Collections;
using System.Collections.Generic;
using SinuousProductions;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public DeckManager deckManager;

    public GameObject cardPrefab;
    public Transform handTransform;
    public float fanSpread = 5f;
    public float cardSpacing = 5f;
    public float verticalSpacing = 5f;

    public List<GameObject> cardsInHand = new();

    public int maxHandSize = 12;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddCardToHand(Card cardData)
    {
        if( cardsInHand.Count < maxHandSize)
        {
            GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
            cardsInHand.Add(newCard);

            var cardDisplay = newCard.GetComponent<CardDisplay>();
            cardDisplay.cardData = cardData;
            cardDisplay.UpdateCardDisplay();

        }

        UpdateHandVisuals();
    }

    private void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;
        if (cardCount == 1)
        {
            cardsInHand[0].transform.localRotation = Quaternion.Euler(0, 0, 0);
            cardsInHand[0].transform.localPosition = new Vector3(0, 0, 0);
            return;
        }

        for (int i = 0; i < cardCount; i++)
        {
            float rotationAngle = fanSpread * (i - (cardCount - 1) / 2f);
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);


            float horizontalOffset = cardSpacing * (i - (cardCount - 1) / 2f);

            float normalizedPostion = (2f * i / (cardCount - 1) - 1f); // cong thuc parabol
            float verticalOffset = verticalSpacing * (1 - normalizedPostion * normalizedPostion);
            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }

    private void Update()
    {
        //if (cardsInHand.Count > 0)
        //{
        //    UpdateHandVisuals();
        //}
    }
}
