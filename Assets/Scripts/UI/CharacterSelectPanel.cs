using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelectPanel : MonoBehaviour
{
    public Animator spriteAnimator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public CharacterData characterData;

    public void Initialize(CharacterData data) {
        spriteAnimator.runtimeAnimatorController = data.animController;
        nameText.text = data.name;
        characterData = data;
        //descriptionText.text = data.description;
    }

    public void SelectThisCharacter() {
        CharacterSelectManager csm = GameObject.FindObjectOfType<CharacterSelectManager>();
        if (csm) {
            csm.SelectCharacter(this);
        }
    }
}
