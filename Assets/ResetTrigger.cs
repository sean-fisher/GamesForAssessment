using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        PushableObject pushableObject = GameObject
            .Find("PushableObject")
            .GetComponent<PushableObject>();

        pushableObject.ResetPuzzle();
    }
}
