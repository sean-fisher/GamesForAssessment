using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour {
    public Vector2 goal;
    public bool complete = false;
    private bool pushing = false;

    void OnCollisionEnter2D(Collision2D other) {
        // If the block puzzle is complete, don't waste time and let the player continue to push
        // the block around
        if (!this.complete) {
            // Get the colliders involved int he collition
            var coll = other.collider;

            // If the other oject it collided with is the player character, do the following:
            if (other.gameObject.GetComponent<PlayerCharacter>()) {
                // Get the position of the block and the position of the player character and find
                // the distance in x and y between them
                var selfPosition = this.transform.position;
                var otherPosition = coll.transform.position;
                var delta = selfPosition - otherPosition;
                var mask = LayerMask.GetMask("Default");

                // If the player character has a greater delta in the x direction, then the player
                // is pushing the block to the left or right, so we want to lerp along x axis. If 
                // the delta is greater in the y direction, then they want to push the block on the
                // y axis. 
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y)) {
                    // Find the direction along the x (left or right) and create a unit vector that
                    // goes to the left or right. Send a raycast in that direction for 100 units. If
                    // The raycast collides with anything, find the location of the collision, and
                    // lerp the block to that position. This will put the block right next to
                    // What the raycast collided with.
                    Vector3 ray = (Vector3)(Vector2.right * Mathf.Sign(delta.x));
                    RaycastHit2D collision = Physics2D.Raycast(selfPosition + (ray / 2), ray, 100, mask);
                    Vector2 dest = new Vector2(Mathf.Round(collision.distance) * Mathf.Sign(delta.x), 0);

                    // Run lerp to destination
                    StartCoroutine(this.Push((Vector2)selfPosition + dest));
                } else {
                    // Find the direction along the y (up or down) and create a unit vector that
                    // goes up or down. Send a raycast in that direction for 100 units. If
                    // The raycast collides with anything, find the location of the collision, and
                    // lerp the block to that position. This will put the block right next to
                    // What the raycast collided with.
                    Vector3 ray = (Vector3)(Vector2.up * Mathf.Sign(delta.y));
                    RaycastHit2D collision = Physics2D.Raycast(selfPosition + (ray / 2), ray, 100, mask);
                    Vector2 dest = new Vector2(0, Mathf.Round(collision.distance) * Mathf.Sign(delta.y));

                    // Run lerp to destination
                    StartCoroutine(this.Push((Vector2)selfPosition + dest));
                }
            }
        }
    }

    IEnumerator Push(Vector2 destination) {
        // If goal is not null and the destination we're lerping to is our goal, then the puzzle is
        // finished, so set the bool and prevent the block from being pushed any further.
        if (this.goal != null) {
            if (destination == this.goal) {
                this.complete = true;
            }
        }

        // Set the pushing flag so the block can't be pushed while it's moving
        this.pushing = true;
        // Round our destination to an integer so that the block will move a fixed distance. We
        // want it to move strictly on a grid so it must move by whole number increments.
        destination.x = Mathf.Round(destination.x);
        destination.y = Mathf.Round(destination.y);

        // Do the lerp
        for (float i = 0f; i < 1f; i += Time.deltaTime) {
            transform.position = Vector2.Lerp(transform.position, destination, i);
            yield return null;
        }

        // The loop above doesn't actually fully move the block to the coords we want, it moves it
        // to just before it, so we lerp the last step to our destination. 
        transform.position = Vector2.Lerp(transform.position, destination, 1f);
        // Flip the pushing flag again, now the block can be pushed again.
        this.pushing = false;
    }
}
