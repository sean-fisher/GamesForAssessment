using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData {
    public string name;
    public string description;
    public RuntimeAnimatorController animControler;
}

public class CharacterSelectManager : MonoBehaviour
{
    public CharacterSelectPanel characterSelectPanelPrefab;
    public CharacterData[] characters;

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

        foreach (Transform child in transform) {
            CharacterSelectPanel p = child.GetComponent<CharacterSelectPanel>();
            if (p && p != panel) {
                p.spriteAnimator.SetBool("WalkInPlace", false);
            }
        }
    }
}
