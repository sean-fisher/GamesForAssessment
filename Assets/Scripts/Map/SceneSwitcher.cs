using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    static SceneSwitcher singleton;
    public static SceneSwitcher Singleton() {
        return singleton;
    }

    System.DateTime timeEnteredCurrentRoom;
    string currentSceneName;

    //public string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        if (singleton == null) {
            Debug.Log("Set up sceneswitcher singleton");
            singleton = this;
            timeEnteredCurrentRoom = System.DateTime.Now;
            currentSceneName = SceneManager.GetActiveScene().name;

        } else {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchToScene(string sceneName) {

        MetricsManager.Singleton().AddRoomTime(
            currentSceneName, 
            (float) System.DateTime.Now.Subtract(timeEnteredCurrentRoom).TotalSeconds);

        currentSceneName = sceneName;
        SceneManager.LoadScene(sceneName);
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
