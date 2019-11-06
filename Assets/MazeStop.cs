using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeStop : MonoBehaviour {
    // Start is called before the first frame update
    float endTime;
    void Start() {}
    // Update is called once per frame
    void Update() {}

    // Stop the maze timer
    void OnTriggerEnter2D(Collider2D other) {
        MazeTimer timer = transform.parent.gameObject.GetComponent<MazeTimer>();
        timer.TimerStop();
        timer.Finish();
    }
}
