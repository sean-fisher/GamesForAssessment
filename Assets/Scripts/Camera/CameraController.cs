using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector2 startPosition;
    public Vector2 cameraBounds;
    public Transform thingToFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPosition();
        
    }

    void FixedUpdate() {
    }

    void UpdateCameraPosition() {
        if (thingToFollow) {
            Vector2 desiredLoc = thingToFollow.position;
            float newX = desiredLoc.x;
            if (newX > cameraBounds.x + startPosition.x) {
                newX = cameraBounds.x + startPosition.x;
            } else if (newX < startPosition.x) {
                newX = startPosition.x;
            }
            float newY = desiredLoc.y;
            if (newY > cameraBounds.y + startPosition.y) {
                newY = cameraBounds.y + startPosition.y;
            } else if (newY < startPosition.y) {
                newY = startPosition.y;
            }

            transform.position = new Vector3(newX, newY, transform.position.z);
        }
    }

    public void UpdateBoundsSettings(CameraBoundsSettings settings) {

        if (settings) {
            this.startPosition = settings.startPosition;
            this.cameraBounds = settings.cameraBounds;
        }
    }
}
