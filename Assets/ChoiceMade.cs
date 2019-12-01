using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMade : MonoBehaviour
{

    public static bool choiceMade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (choiceMade == true)
        {
            gameObject.SetActive(false);
        }
    }
}
