using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CharacterData {
    public string name;
    public string description;
    public RuntimeAnimatorController animController;
}

public class CharacterSelectManager : MonoBehaviour
{
    public CharacterSelectPanel characterSelectPanelPrefab;
    public GameObject uiToEnableWhenSelected;
    public TextMeshProUGUI descriptionText;
    public CharacterData[] characters;
    CharacterData selectedCharacter;
    

    void Start() {
        Initialize();
    }

    void Initialize() {
        CreateCharacterSelectPanels();
    }

    void CreateCharacterSelectPanels() {
        foreach (CharacterData data in characters) {
            CharacterSelectPanel newPanel = GameObject.Instantiate(characterSelectPanelPrefab);
            newPanel.transform.SetParent(this.transform);
            newPanel.Initialize(data);
        }
    }

    public void SelectCharacter(CharacterSelectPanel panel) {
        panel.spriteAnimator.SetBool("WalkInPlace", true);
        selectedCharacter = panel.characterData;
        descriptionText.text = selectedCharacter.description;

        foreach (Transform child in transform) {
            CharacterSelectPanel p = child.GetComponent<CharacterSelectPanel>();
            if (p && p != panel) {
                p.spriteAnimator.SetBool("WalkInPlace", false);
            }
        }

        uiToEnableWhenSelected.SetActive(true);
    }

    public void ConfirmSelection() {
        GameManager.Singleton().ActivePlayerCharacter.Initialize(selectedCharacter);
    }
}
