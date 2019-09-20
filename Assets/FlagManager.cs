using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    static Dictionary<int, bool> flags;

    public static void Initialize() {
        flags = new Dictionary<int, bool>();
    }

    public static void SetFlag(int flag, bool value) {
        flags[flag] = value;
    }
}
