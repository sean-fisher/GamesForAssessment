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
    public GameObject player;
    public GameObject table;
    public static int matches = 0;
    public static int wrongMatch = 0;
    public static double consci = 1.00;

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
        Invoke("CheckMatch", (float)1.5);
    }

    public void CheckMatch() {
        if (prevCard) {
            // if the cards match
            if (lastCardFlipped.GetComponent<SpriteRenderer>().sprite == prevCard.GetComponent<SpriteRenderer>().sprite) {
                matches++;
                // make the cards disappear if right match
                lastCardFlipped.gameObject.SetActive(false);
                prevCard.SetActive(false);
                if (matches == 6) {
                    table.transform.localScale = new Vector3(1, 1, 1);
                    player.SetActive(true);
                }
            }  else {
                wrongMatch++; // add to the wrong match count
                Debug.Log("Wrong Match = " + wrongMatch);
                if (consci != 0) {
                    consci -= 0.16; // score for consciencsiousness lowers when they make a wrong match
                    if (consci < 0.04) {
                        consci = 0;
                    }
                    Debug.Log("Consci = " + consci);
                }
                // flip cards back over if wrong match
                prevCard.GetComponent<SpriteRenderer>().sprite = cardBack;
                lastCardFlipped.GetComponent<SpriteRenderer>().sprite = cardBack;
            }
            prevCard = null;
            lastCardFlipped = null;         
        }
    }
}
