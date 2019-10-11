using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsSettings : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 cameraBounds;

    void Awake() {

        CameraController cc = GameObject.FindObjectOfType<CameraController>();

        if (cc) {
            cc.UpdateBoundsSettings(this);
        }
    }
}
