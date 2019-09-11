using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float maxSpeed;
    public bool controlDisabled;

    Rigidbody2D rb;
    Vector2 movement;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        if (!controlDisabled)
        {
            Vector2 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (input.magnitude > 1)
            {
                input = input.normalized;
            }

            movement = input * maxSpeed;
        } else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void FixedUpdate() {

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactable = other.gameObject.GetComponent<Interactable>();
        if (interactable)
        {
            interactable.StartInteraction(this.gameObject);
        }
    }
}
