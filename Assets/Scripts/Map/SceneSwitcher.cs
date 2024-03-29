﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    static SceneSwitcher singleton;
    public static SceneSwitcher Singleton() {
        if (singleton == null) {
            //singleton = new SceneSwitcher();
        }
        return singleton;
    }

    System.DateTime timeEnteredCurrentRoom;
    string lastSceneName;
    string currentSceneName;
    Cardinal lastLoadzoneCardinal;

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

        if (sceneName.EndsWith("\n") || sceneName.EndsWith("\r")) {
            sceneName = sceneName.Substring(0, sceneName.Length - 1);
        }
        lastSceneName = SceneManager.GetActiveScene().name;
        MetricsManager.Singleton().AddRoomTime(
            currentSceneName, 
            (float) System.DateTime.Now.Subtract(timeEnteredCurrentRoom).TotalSeconds);
        timeEnteredCurrentRoom = System.DateTime.Now;

        currentSceneName = sceneName;
        SceneManager.LoadScene(sceneName);
    }

    public void PrepareToPlacePlayerAfterLoad() {
        SceneManager.sceneLoaded += PlacePlayerAfterLoadNewScene;
    }

    public void PlacePlayerAfterLoadNewScene(Scene scene, LoadSceneMode mode) {
        
        Loadzone whereToLoad = FindLoadzoneToSpawnAt(lastSceneName, currentSceneName);
        //whereToLoad.gameObject.SetActive(false);
        PlayerCharacter.Singleton().transform.position = whereToLoad.exitPosition;
        SceneManager.sceneLoaded -= PlacePlayerAfterLoadNewScene;
    }

    public static Loadzone FindLoadzoneToSpawnAt(string sceneEnteredFrom, string currentSceneName) {
        var zones = GameObject.FindObjectsOfType<Loadzone>();
        Loadzone loadZoneSpecifying = null;
        foreach (Loadzone zone in zones) {
            if (zone.loadSpecifiedRoomInsteadOfCardinal) {
                if (sceneEnteredFrom == zone.SceneToLoad) {
                    loadZoneSpecifying = zone;
                }
            } else {
                string rnt = MapLayout.GetRoomNextTo(currentSceneName, zone.whichSideOfRoom);
                if (sceneEnteredFrom == rnt) {
                    //GetOppositeCardinal(zone.whichSideOfRoom)) {
                    return zone;
                }
            }
        }
        return loadZoneSpecifying;
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
