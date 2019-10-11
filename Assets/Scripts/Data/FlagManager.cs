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
        if (flags == null) Initialize();
        flags[flag] = value;
    }
    public static bool IsFlagSet(int flag) {
        if (flags == null) Initialize();
        return flags[flag];
    }
}
