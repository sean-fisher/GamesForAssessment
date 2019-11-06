using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeStart : MonoBehaviour {
    // Start is called before the first frame update
    float startTime;
    void Start() {}
    // Update is called once per frame
    void Update() {}

    // Start the maze timer
    void OnTriggerEnter2D(Collider2D other) {
        // this.startTime = Time.time;

        MazeTimer timer = transform.parent.gameObject.GetComponent<MazeTimer>();
        timer.TimerStart();
    }
}
