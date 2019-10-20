using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryTile : MonoBehaviour
{
    public Sprite cardFront;
    public Sprite cardBack;
    public static GameObject lastCardFlipped;
    public static GameObject prevCard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        // save previously flipped card
        prevCard = lastCardFlipped;

        // when card is clicked, flip the card (change the image)
        GetComponent<SpriteRenderer>().sprite = cardFront;
        lastCardFlipped = this.gameObject;

        // check to see if cards match after a delay
        Invoke("CheckMatch", 2);
    }

    public void CheckMatch() {
        if (prevCard) {
            if (lastCardFlipped.GetComponent<SpriteRenderer>().sprite == prevCard.GetComponent<SpriteRenderer>().sprite) {
                // make the cards disappear if right match
                lastCardFlipped.gameObject.SetActive(false);
                prevCard.SetActive(false);
                prevCard = null;
                lastCardFlipped = null;
            }  
            prevCard.GetComponent<SpriteRenderer>().sprite = cardBack;
            lastCardFlipped.GetComponent<SpriteRenderer>().sprite = cardBack;
            prevCard = null;
            lastCardFlipped = null;         
        }
    }
}
