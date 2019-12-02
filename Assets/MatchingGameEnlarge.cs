using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingGameEnlarge : MonoBehaviour
{

    public GameObject Cards;
    public GameObject table;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCharacter>())
        {
            table.transform.localScale = new Vector3(7, 7, 1);
            Cards.SetActive(true);
            table.GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Singleton().matchComplete = true;
            GameManager.Singleton().ActivePlayerCharacter.gameObject.SetActive(false);
        } 
    }
}
