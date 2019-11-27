using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThiefChoice : MonoBehaviour
{
    public GameObject ChoicePanel;
    public static bool notanswered = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Enter");
        //    BulletinPanel.SetActive(!BulletinPanel.activeSelf);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (notanswered)
        {
            if (collision.GetComponent<PlayerCharacter>())
            {
                ChoicePanel.SetActive(true);
                notanswered = false;
                GetComponent<ThiefEscape>().nocollision = false;
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<PlayerCharacter>())
    //    {
    //        ChoicePanel.SetActive(false);
    //    }
    //}

}
