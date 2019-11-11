using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMgr : MonoBehaviour {
    public int moves = 0;
    public int resets = 0;
    private int optimalMoves = 7;
    private int optimalResets = 0;
    // Start is called before the first frame update
    public void Move() {
        this.moves++;
    }

    public void ResetPuzzle() {
        this.resets++;
    }
}
