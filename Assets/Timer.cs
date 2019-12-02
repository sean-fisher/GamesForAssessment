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
        GameManager.Singleton().bhickenComplete = true;
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

        var pens = GameObject.FindObjectsOfType<PenCollider>();
        float summ = 0;
        foreach (PenCollider pen in pens) {
            summ += pen.GetAverageScore();
        }
        summ /= pens.Length * 6f;
        Bhicken.bhickenScore = summ;

        MetricsManager.Singleton().stats.bhicken_sorted_score = summ;
        MetricsManager.Singleton().stats.bhicken_orderliness = summ;

        GameManager.Singleton().bhickenComplete = true;
    }
}
