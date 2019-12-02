using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchHelper : MonoBehaviour
{
    // this is intended to help UI buttons, etc. load other scenes 
    // without creating a new script for each button

    public void LoadScene(string sceneName) {
        SceneSwitcher.Singleton().SwitchToScene(sceneName);
    }

    public void BeginGame() {
        SceneSwitcher.Singleton().SwitchToScene("Town Center");
    }
    
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
