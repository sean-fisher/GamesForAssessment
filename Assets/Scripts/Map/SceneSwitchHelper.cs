using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
