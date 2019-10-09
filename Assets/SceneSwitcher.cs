using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    //public string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void GoToScene()
    //{
    //    if (SceneToLoad != "")
    //    {
    //        SceneManager.LoadScene(SceneToLoad);
    //    }
    //    else
    //    {
    //        Debug.Log("Scene has not been set!");
    //    }

    //}



    public void GotoShopScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void GotoForestRiverScene()
    {
        SceneManager.LoadScene("ForestRiver");
    }

    public void GotoForestScene()
    {
        SceneManager.LoadScene("ForestScene");
    }

    public void GotoSbRoomScene()
    {
        SceneManager.LoadScene("SbRoom");
    }

    public void GotoParkScene()
    {
        SceneManager.LoadScene("Park");
    }
}
