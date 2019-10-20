﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Loadzone : MonoBehaviour
{
    public string SceneToLoad;
    public Cardinal whichSideOfRoom;

    // Start is called before the first frame update
    void Start()
    {
        GuessCardinal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerCharacter>())
        {
            if (true) {

                SceneManager.LoadScene(MapLayout.GetRoomNextTo(SceneManager.GetActiveScene().name, whichSideOfRoom));
            } else {
                if (SceneToLoad != "")
                {
                    SceneManager.LoadScene(SceneToLoad);
                } else
                {
                    Debug.Log("Scene to Load has not been set!");
                }
            }
        } else
        {
            Debug.Log("Non player character entered load zone");
        }
    }

    void GuessCardinal() {
        Loadzone[] allLoadZonesInRoom = GameObject.FindObjectsOfType<Loadzone>();



        Loadzone eastZone = allLoadZonesInRoom[0];
        Loadzone northZone = allLoadZonesInRoom[0];
        Loadzone westZone = allLoadZonesInRoom[0];
        Loadzone southZone = allLoadZonesInRoom[0];;

        float eastX = eastZone.transform.position.x;
        float northY = northZone.transform.position.y;
        float westX = westZone.transform.position.x;
        float southY = southZone.transform.position.y;

        foreach (Loadzone zone in allLoadZonesInRoom) {
            float x = zone.transform.position.x;
            float y = zone.transform.position.y;
            if (x > eastX) {
                eastX = x;
                eastZone = zone;
            }
            if (y > northY) {
                northY = y;
                northZone = zone;
            }
            if (x < westX) {
                westX = x;
                westZone = zone;
            }
            if (y < southY) {
                southY = y;
                southZone = zone;
            }
        }

        eastZone.whichSideOfRoom  = Cardinal.EAST;
        northZone.whichSideOfRoom = Cardinal.NORTH;
        westZone.whichSideOfRoom  = Cardinal.WEST;
        southZone.whichSideOfRoom = Cardinal.SOUTH;
    }
}
