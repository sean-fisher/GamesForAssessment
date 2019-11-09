using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTimer : MonoBehaviour {
    // Start is called before the first frame update
    System.DateTime startTime;
    System.DateTime endTime;
    int span;
    bool finished = false;

    void Start() {
        if (GameObject.FindObjectOfType<MazeTimer>() != null) {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update() {}

    public void TimerStart() {
        if (!this.finished)
            this.startTime = System.DateTime.Now;
    }

    public void TimerStop() {
        if (!this.finished)
            this.endTime = System.DateTime.Now;
    }

    public void Finish() {
        if (!this.finished) {
            System.TimeSpan span = endTime.Subtract(startTime);

            Debug.Log("Starting Time: " + this.startTime.ToString("yyyy/MM/dd HH:mm:ss"));
            Debug.Log("Ending Time: " + this.endTime.ToString("yyyy/MM/dd HH:mm:ss"));
            Debug.Log("Total time: " + span.Seconds);

            this.span = span.Seconds;
            this.finished = true;
        }
    }
}
