using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{

    public ScrollingTextBox DialogueText;

    public delegate void OnFinishDialogueDelFunc();
    public OnFinishDialogueDelFunc onFinishDialogue;

    // Start is called before the first frame update
    void Start()
    {
        DialogueText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayDialogue(string[] textToDisplay)
    {
        DialogueText.DisplayDialogue(textToDisplay);
        DialogueText.onFinishDialogue += EndDialogue;
    }

    public void EndDialogue()
    {
        onFinishDialogue();
    }
}
