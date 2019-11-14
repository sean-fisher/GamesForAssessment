using UnityEngine;
using System.Collections;

public class ThiefEscape : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(-2, -2, 0);
    private Vector3 pos2 = new Vector3(9, -2, 0);
    public float speed = 1.0f;
    private bool nocollision = true;
    //private string collidedobject;

    void Update()
    {
        if (nocollision)
        {
            transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        }

    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.name == "PlayerCharacter")
        {
            //Rigidbody rbdy = collision.gameObject.GetComponent<Rigidbody>();

            //Stop Moving/Translating
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            nocollision = false;

            ////Stop rotating
            //rbdy.angularVelocity = Vector3.zero;

        }
    }

    void OnCollisionExit2D(Collision2D collide)
    {
        if (collide.gameObject.name == "PlayerCharacter")
        {
            //Rigidbody rbdy = collision.gameObject.GetComponent<Rigidbody>();

            //Stop Moving/Translating
            //GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            nocollision = true;

            ////Stop rotating
            //rbdy.angularVelocity = Vector3.zero;

        }
    }

    //void OnCollisionEnter(UnityEngine.Collision hit)
    //{
    //    collidedobject = hit.gameObject.name;
    //    if (collidedobject == "PlayerCharacter")
    //    {
    //        nocollision = false;
    //    }
    //}
}
