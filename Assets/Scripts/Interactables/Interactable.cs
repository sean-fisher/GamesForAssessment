using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Interactable : MonoBehaviour
{
    public bool requiresButtonPressToInteract;

    protected GameObject objectThatWeAreInteractingWith;

    public virtual void StartInteraction(GameObject interactor)
    {
        objectThatWeAreInteractingWith = interactor;
    }
    public virtual void EndInteraction()
    {

    }
}
