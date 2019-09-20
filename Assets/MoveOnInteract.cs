using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnInteract : Interactable
{
    public Transform targetLocation;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void StartInteraction(GameObject interactor) {
        base.StartInteraction(interactor);

        StartCoroutine(MovingToDestination());
    }

    public void MoveToDestination() {

    }

    IEnumerator MovingToDestination() {

        Vector3 startPos = transform.position;
        Vector3 destination = targetLocation.position;
        float distanceToTravel = (destination - startPos).magnitude;

        while ((destination - transform.position).magnitude > .5f) {

            transform.position += (destination - transform.position).normalized * Time.deltaTime * moveSpeed;
            float progress = (transform.position - startPos).magnitude / distanceToTravel;
            
            Debug.Log("Progress: " + progress);
            if (progress > .95f) {
                break;
            }
            yield return null;
        }

        transform.position = destination;
    }
}
