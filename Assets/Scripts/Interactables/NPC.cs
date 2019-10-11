using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConditionDialoguePair {
    public Condition condition;
    public string[] dialogue;
}

public class NPC : Sign
{
    public List<ConditionDialoguePair> conditionalDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override string[] GetTextToDisplay() {

        foreach (ConditionDialoguePair pair in conditionalDialogue) {
            if (pair.condition.IsMet()) {
                return pair.dialogue;
            }
        }
        return dialogueToDisplay;
    }
}
