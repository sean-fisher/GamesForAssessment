﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable
{
    public string[] dialogueToDisplay;
    public bool stopsPlayerWhileReading = true;
    public static double agreeable = 1.00;

    public  bool destroyOnFinish;


    public override void StartInteraction(GameObject interactor)
    {
        base.StartInteraction(interactor);

        PlayerCharacter pc = interactor.GetComponent<PlayerCharacter>();
        if (pc)
        {
            pc.controlDisabled = true;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                agreeable -= 0.10;
                Debug.Log("Agreeableness score: " + agreeable);
            }

        }

        MainUI ui = GameObject.FindObjectOfType<MainUI>();

        ui.DisplayDialogue(GetTextToDisplay());
        ui.onFinishDialogue += EndInteraction;
    }

    public override void EndInteraction()
    {
        base.EndInteraction();

        PlayerCharacter pc = objectThatWeAreInteractingWith.GetComponent<PlayerCharacter>();
        if (pc)
        {
            pc.controlDisabled = false;
        }

        if (destroyOnFinish) {
            Destroy(this.gameObject);
        }
    }

    public virtual string[] GetTextToDisplay() {
        return dialogueToDisplay;
    }
}
