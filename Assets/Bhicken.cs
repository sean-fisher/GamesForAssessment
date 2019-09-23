using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public float speed;


// Start is called before the first frame update


//// Update is called once per frame
//void Update()
//{
//    transform.position += Time.deltaTime * new Vector3(speed, 0, 0); //every frame add one unit on the x to position


//}

public class Bhicken : MonoBehaviour
{

    private bool dirRight = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 4.0f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -4)
        {
            dirRight = true;
        }
    }
}
