using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryTile : MonoBehaviour
{
    public Sprite cardFront;
    public Sprite cardBack;
    public static GameObject lastCardFlipped;
    bool flip = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {

        GameObject lastCard = lastCardFlipped;

        // when card is clicked, change the image (flip the card)
        if (flip) {
            GetComponent<SpriteRenderer>().sprite = cardFront;
            flip = !flip;
            lastCardFlipped = this.gameObject;
        } else {
            GetComponent<SpriteRenderer>().sprite = cardBack;
            flip = !flip;
        }

        // check to see if the cards match
        if (lastCard) {
            if (this.GetComponent<SpriteRenderer>().sprite == lastCard.GetComponent<SpriteRenderer>().sprite) {
                // make the cards disappear if right match
                this.gameObject.SetActive(false);
                lastCard.SetActive(false);
                lastCard = null;
                lastCardFlipped = null;
            }            
        }
    }
}
