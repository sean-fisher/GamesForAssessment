using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsSettings : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 cameraBounds;

    void Start() {

        //CameraController cc = CameraController.Singleton();
        CameraController cc = GameObject.FindObjectOfType<CameraController>();

        if (cc) {
            cc.UpdateBoundsSettings(this);
        }
    }
}
