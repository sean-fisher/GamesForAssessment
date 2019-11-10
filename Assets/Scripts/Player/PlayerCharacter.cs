using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float maxSpeed;
    public bool controlDisabled;
    public bool moveDisabled;

    Rigidbody2D rb;
    Animator anim;
    Vector2 movement;
    bool isUsingObject;

    public Pickupable pickedUpItem;
    public Usable objectToUse;

    static PlayerCharacter singleton;
    public static PlayerCharacter Singleton() {return singleton;}


    void Awake() {

        if (singleton == null) {
            singleton = this;
        } else {
            Destroy(this.gameObject);
            return;
        }

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<CameraController>().thingToFollow = transform;
    }

    public void Initialize(CharacterData data) {
        anim.runtimeAnimatorController = data.animController;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        if (!controlDisabled)
        {
            if (!moveDisabled)
            {
                Vector2 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                if (input.magnitude > 1)
                {
                    input = input.normalized;
                }

                movement = input * maxSpeed;

                if (input.sqrMagnitude > 0) {
                    anim.SetFloat("XSpeed", input.x);
                    anim.SetFloat("YSpeed", input.y);
                    anim.SetFloat("Gait", 1);
                }
                else {
                    anim.SetFloat("Gait", 0);

                }
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
