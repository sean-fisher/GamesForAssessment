using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConditionType {
    HAS_ITEM,
    FLAG_SET
}

[System.Serializable]
public class Condition
{
    public ConditionType conditionType;
    public int requiredFlag;

    public bool IsMet() {
        switch (conditionType) {
            case (ConditionType.FLAG_SET):
                return FlagManager.IsFlagSet(requiredFlag);
            case (ConditionType.HAS_ITEM):
                Debug.Log("Item Condition is not implemented yet");
                return false;
        }
        return false;
    }

}
