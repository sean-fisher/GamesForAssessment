using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public void SetFlag(bool newVal) {
        FlagManager.SetFlag(GetInstanceID(), newVal);
    }
}
