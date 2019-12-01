using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefAction : MonoBehaviour
{
    public GameObject TurnedInThiefPanel;
    public GameObject HelpedThiefPanel;
    private GameObject catchThiefPanel;
    private GameObject thiefObject;
    public static double honesty = 1.00;

    private Vector3 pos1 = new Vector3(-2, -2, 0);
    private Vector3 pos2 = new Vector3(9, -2, 0);
    public float speed = 1.0f;
    private bool nocollision = true;

    public static bool choiceMade;

    //private string collidedobject;

    // Start is called before the first frame update
    void Start()
    {
        catchThiefPanel = GameObject.Find("CatchThief");
        thiefObject = GameObject.Find("Thief");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HelpThief()
    {
        honesty = 0.00;
        //GameObject.Find("Thief").SetActive(false);
        GameObject.Find("Thief").transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        choiceMade = true;
        //catchThiefPanel.gameObject.SetActive(false);
        //HelpedThiefPanel.SetActive(true);

    }

    public void GetRidOfThief()
    {
        honesty = 1.00;
        GameObject.Find("Thief").SetActive(false);
        choiceMade = true;
        //catchThiefPanel.gameObject.SetActive(false);
        //TurnedInThiefPanel.SetActive(true);
        
        GameManager.Singleton().thiefComplete = true;
        GameManager.Singleton().CheckComplete();
    }


}
