using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour {
    public Rigidbody2D rbody;

    void Start() {
        this.rbody = this.GetComponent<Rigidbody2D>();
    }

    void Update() {}

    void OnCollisionEnter2D(Collision2D other) {
        var coll = other.collider;

        if (other.gameObject.GetComponent<PlayerCharacter>()) {
            var selfPosition = this.transform.position;
            var otherPosition = coll.transform.position;

            var delta = selfPosition - otherPosition;

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y)) {
                if (!Physics.Raycast(selfPosition, (Vector3)(Vector2.right * Mathf.Sign(delta.x)), 5)) {
                // if (!Physics.Raycast(selfPosition, new Vector3(Mathf.Sign(delta.x) * 1, 0, 0), 5)) {
                    StartCoroutine(this.Push((Vector2)selfPosition + new Vector2(Mathf.Sign(delta.x) * 1, 0)));
                }
            } else {
                if (!Physics.Raycast(selfPosition, new Vector3(0, Mathf.Sign(delta.y) * 1, 0), 5)) {
                    StartCoroutine(this.Push((Vector2)selfPosition + new Vector2(0, Mathf.Sign(delta.y) * 1)));
                }
            }
        }
    }

    IEnumerator Push(Vector2 destination) {
        destination.x = Mathf.Round(destination.x);
        destination.y = Mathf.Round(destination.y);

        for (float i = 0f; i < 1f; i += Time.deltaTime) {
            transform.position = Vector2.Lerp(transform.position, destination, i);
            yield return null;
        }

        transform.position = Vector2.Lerp(transform.position, destination, 1f);
    }
}
