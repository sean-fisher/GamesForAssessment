using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletinBoard : MonoBehaviour
{
    public GameObject BulletinPanel;
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
        Debug.Log("Enter trigger");
        if (collision.GetComponent<PlayerCharacter>())
        {
            BulletinPanel.SetActive(true);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCharacter>())
        {
            BulletinPanel.SetActive(false);
        }
    }

}
