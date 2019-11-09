using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour {
    public Rigidbody2D rbody;
    private bool pushing = false;

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
            LayerMask mask = LayerMask.GetMask("Default");

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y)) {
                Debug.DrawRay(selfPosition, (Vector3)(Vector2.right * Mathf.Sign(delta.x)), Color.black, 20.0f);
                var ray = (Vector3)(Vector2.right * Mathf.Sign(delta.x));
                RaycastHit2D collision = Physics2D.Raycast(selfPosition + (ray / 2), ray, 100, mask);
                Debug.Log("Hit Something : " + collision.distance);

                Vector2 dest = new Vector2(Mathf.Round(collision.distance) * Mathf.Sign(delta.x), 0);
                StartCoroutine(this.Push((Vector2)selfPosition + dest));

                // if (!Physics2D.Raycast(selfPosition + (ray / 2), ray, 100, mask) && !this.pushing) {
                //     StartCoroutine(this.Push((Vector2)selfPosition + new Vector2(Mathf.Sign(delta.x) * 1, 0)));
                    
                // }
            } else {
                var ray = (Vector3)(Vector2.up * Mathf.Sign(delta.y));

                RaycastHit2D collision = Physics2D.Raycast(selfPosition + (ray / 2), ray, 100, mask);
                Debug.Log("Hit Something : " + collision.distance);
                Debug.DrawRay(selfPosition + (ray / 2), ray, Color.black, 20.0f);
                Vector2 dest = new Vector2(0, Mathf.Round(collision.distance) * Mathf.Sign(delta.y));
                StartCoroutine(this.Push((Vector2)selfPosition + dest));
                // if (!Physics2D.Raycast(selfPosition + (ray / 2), ray, 100, mask) && !this.pushing) {
                //     StartCoroutine(this.Push((Vector2)selfPosition + new Vector2(0, Mathf.Sign(delta.y) * 1)));
                // }
            }
        }
    }

    IEnumerator Push(Vector2 destination) {
        this.pushing = true;
        destination.x = Mathf.Round(destination.x);
        destination.y = Mathf.Round(destination.y);

        for (float i = 0f; i < 1f; i += Time.deltaTime) {
            transform.position = Vector2.Lerp(transform.position, destination, i);
            yield return null;
        }

        transform.position = Vector2.Lerp(transform.position, destination, 1f);
        this.pushing = false;
    }
}
