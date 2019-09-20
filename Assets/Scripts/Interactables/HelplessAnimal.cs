using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelplessAnimal : Interactable
{
    public override void StartInteraction(GameObject interactor)
    {
        base.StartInteraction(interactor);

        PlayerCharacter pc = interactor.GetComponent<PlayerCharacter>();

        if (pc != null && pc.pickedUpItem != null) {
            Balloon b = pc.pickedUpItem.GetComponent<Balloon>();
            if (b)
            {
                StartRescue(pc, b);
            }
        }
    }
    public override void EndInteraction()
    {
        base.EndInteraction();

    }

    void StartRescue(PlayerCharacter pc, Balloon b)
    {
        b.transform.parent = this.transform;
        b.transform.localPosition = new Vector3(0, transform.localScale.y);
        pc.moveDisabled = true;
        pc.objectToUse = b;
    }
}
