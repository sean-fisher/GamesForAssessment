using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Seconds before the game forcibly ends
    public float gameTimeoutTime = 10;
    float timeSinceGameStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceGameStart += Time.deltaTime;

        if (timeSinceGameStart > gameTimeoutTime)
        {
            Debug.Log("Time over!");
            EndGame();
        }

    }
    void EndGame()
    {
        Debug.Log("Ending Game");
        InputManager.ifFinished = true;
    }
}
