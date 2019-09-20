using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
    public override void StartInteraction(GameObject interactor)
    {
        base.StartInteraction(interactor);

        PlayerCharacter pc = interactor.GetComponent<PlayerCharacter>();

        if (pc.pickedUpItem)
        {

        } else
        {
            PickThisUp(pc);
        }
    }
    public override void EndInteraction()
    {
        base.EndInteraction();

    }

    public void PickThisUp(PlayerCharacter pickerUpper)
    {
        DisableCollision();
        transform.position = pickerUpper.transform.position + new Vector3(0, pickerUpper.transform.localScale.y);
        transform.parent = pickerUpper.transform;
        pickerUpper.pickedUpItem = this;
    }

    public void DropThisItem()
    {

    }

    protected void DisableCollision()
    {
        var colliders = GetComponents<Collider2D>();
        foreach (Collider2D c in colliders)
        {
            c.enabled = false;
        }
    }
    protected void EnaableCollision()
    {
        var colliders = GetComponents<Collider2D>();
        foreach (Collider2D c in colliders)
        {
            c.enabled = true;
        }
    }
}
