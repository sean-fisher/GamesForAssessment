﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenCollider : MonoBehaviour {
    // Start is called before the first frame update

    int redScore;
    int blueScore;
    int yellowScore;
    int pinkScore;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
    
        if (collision.attachedRigidbody.GetComponent <Bhicken>()) {
            Bhicken b = collision.attachedRigidbody.GetComponent<Bhicken>();
            Color test = b.getColor();
            Debug.Log("hiplswork");
            Debug.Log(test);

            Color red = new Color(207f/255, 42f/255, 42f / 255, 255f / 255);
            Color blue = new Color(72f / 255, 158f / 255, 171f / 255, 255f / 255);
            Color pink = new Color(255f / 255, 100f / 255, 214f / 255, 255f / 255);
            Color yellow = new Color(253f/255, 255f / 255, 0, 255f / 255);


            if (test == red ) {   //red

                redScore++;
                Debug.Log("Color is red");
                Debug.Log("Score is" + redScore);

            }

            if (test == blue) {   //blue

                blueScore++;

            }

            if (test == pink) {   //pink

                pinkScore++;


            }

            if (test == yellow)    //yellow
 {
                yellowScore++;
            }




        }
            
    }
}
