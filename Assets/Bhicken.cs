using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bhicken : MonoBehaviour
{

    private bool dirRight = true;
    public float distanceToTravel = 2.0f;
    public float progress = 0.0f;
    public float movementSpeed = 2.0f;
    public SpriteRenderer sprite; 

    void Update()
    {
        progress += Time.deltaTime / distanceToTravel;

        if (progress > 1)
        {
            dirRight = !dirRight;
            progress = 0;
        }

        if (dirRight)
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * movementSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collide with " + collision.gameObject.name);
        dirRight = !dirRight;
        progress = 0;
    }

    public Color getColor() {
        //if (sprite != null)
        //{
            return sprite.color; 
       // } else {
         //   return new Color();
       // }
    }
}
