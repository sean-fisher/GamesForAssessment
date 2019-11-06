using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingTextBox : MonoBehaviour
{
    public Text contentText;

    public float baseTypeSpeed = 10; // Characters per second
    public float fastTypeSpeed = 30; // Characters per second

    string fullCurrentTypingString;
    int currentTypingIndex;
    int currentDialogueIndex;
    float typingAmount;
    string[] dialogueToDisplay;
    bool textFinishedScrolling;
    bool isFastScrolling;

    public delegate void OnFinishDialogueDelFunc();
    public OnFinishDialogueDelFunc onFinishDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetButtonDown("Submit")) {
            if (textFinishedScrolling)
            {
                AdvanceText();
            } else {
                isFastScrolling = true;
            }
        }
        if  (Input.GetButtonUp("Submit")) {
            isFastScrolling = false;
        }
    }

    public void ClearText()
    {
        contentText.text = "";
        typingAmount = 0;
        currentTypingIndex = 0;
        textFinishedScrolling = true;
    }

    public void DisplayDialogue(string[] textToDisplay)
    {
        ClearText();
        currentDialogueIndex = -1;

        this.gameObject.SetActive(true);

        dialogueToDisplay = textToDisplay;

        if (dialogueToDisplay.Length > 0)
        {
            AdvanceText();
        }
    }

    IEnumerator TypeText()
    {
        float totalTypingTime = ((float)fullCurrentTypingString.Length);// / baseTypeSpeed;
        textFinishedScrolling = false;

        while (currentTypingIndex < fullCurrentTypingString.Length)
        {
            yield return null;
            typingAmount += Time.deltaTime * (isFastScrolling ? fastTypeSpeed : baseTypeSpeed);

            currentTypingIndex = Mathf.Min((int)(typingAmount), fullCurrentTypingString.Length);

            contentText.text = fullCurrentTypingString.Substring(0, currentTypingIndex);
        }

        contentText.text = fullCurrentTypingString;

        textFinishedScrolling = true;
    }

    void AdvanceText()
    {
        if (++currentDialogueIndex >= dialogueToDisplay.Length)
        {
            // We've finished reading the conversation
            this.gameObject.SetActive(false);
            onFinishDialogue();
        }
        else
        {
            fullCurrentTypingString = dialogueToDisplay[currentDialogueIndex];
            ClearText();
            StartCoroutine(TypeText());
        }
    }
}
