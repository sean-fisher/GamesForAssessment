using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bhicken : MonoBehaviour
{
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * new Vector3(speed, 0, 0); //every frame add one unit on the x to position



    }
}