using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainUI : MonoBehaviour
{

    public GameObject pausePanel;
    public ScrollingTextBox DialogueText;

    public delegate void OnFinishDialogueDelFunc();
    public OnFinishDialogueDelFunc onFinishDialogue;

    // Start is called before the first frame update
    void Start()
    {
        if (DialogueText != null) {
            DialogueText.gameObject.SetActive(false);
        }
    }

    bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (isPaused) UnPause(); else Pause();
        }
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

    public void QuitGame() {

        SceneSwitcher.Singleton().SwitchToScene("Title screen");
    }

    public void Pause() {
        pausePanel.SetActive(true);
        GameObject.FindObjectOfType<PlayerCharacter>().controlDisabled = true;
        Time.timeScale = .001f;
        isPaused = true;
    }

    public void UnPause() {
        pausePanel.SetActive(false);
        GameObject.FindObjectOfType<PlayerCharacter>().controlDisabled = false;
        Time.timeScale = 1;
        isPaused = false;
    }
}
