using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float maxSpeed;
    public bool controlDisabled;
    public bool moveDisabled;

    Rigidbody2D rb;
    Vector2 movement;
    bool isUsingObject;

    public Pickupable pickedUpItem;
    public Usable objectToUse;

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
            if (!moveDisabled)
            {
                Vector2 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                if (input.magnitude > 1)
                {
                    input = input.normalized;
                }

                movement = input * maxSpeed;
            }

            if (Input.GetButtonDown("Submit"))
            {
                Interact();
            }
            if (Input.GetButtonDown("Cancel"))
            {
                PressCancel();
            }
        } else
        {
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

    void Interact()
    {
        if (objectToUse != null)
        {
            isUsingObject = true;
            objectToUse.Use(this);
        }
    }

    void PressCancel()
    {
        if (isUsingObject && objectToUse != null)
        {
            if (objectToUse.StopUsing()) {
                StopUsingObject();
            }
        }
    }

    public void StopUsingObject() {
        isUsingObject = false;
    }
}
