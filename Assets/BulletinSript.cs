using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletinScript : Interactable
{
    public string[] dialogueToDisplay;
    public bool stopsPlayerWhileReading = true;

    public override void StartInteraction(GameObject interactor)
    {
        base.StartInteraction(interactor);

        PlayerCharacter pc = interactor.GetComponent<PlayerCharacter>();
        if (pc)
        {
            pc.controlDisabled = true;
        }

        GameManager.GetMainUI().DisplayDialogue(dialogueToDisplay);
        GameManager.GetMainUI().onFinishDialogue += EndInteraction;
    }

    public override void EndInteraction()
    {
        base.EndInteraction();

        PlayerCharacter pc = objectThatWeAreInteractingWith.GetComponent<PlayerCharacter>();
        if (pc)
        {
            pc.controlDisabled = false;
        }
    }
}
