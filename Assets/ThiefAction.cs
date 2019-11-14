using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefAction : MonoBehaviour
{
    public GameObject TurnedInThiefPanel;
    public GameObject HelpedThiefPanel;
    public static double honesty = 1.00;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRidOfThief()
    {
        honesty = 1.00;
        GameObject.Find("Thief").SetActive(false);
        TurnedInThiefPanel.SetActive(true);
    }

    public void HelpThief()
    {
        honesty = 0.00;
        GameObject.Find("Thief").SetActive(true);
        HelpedThiefPanel.SetActive(true);
    }
}
