using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance = null;
    private int score;
    
    void Start() {
        instance = this;
	}
	
	void Update () {
		
	}

    public void AddScore(int toAdd) {
        score += toAdd;
    }

    public void ResetScore() {
        score = 0;
    }

    public int GetScore() {
        return score;
    }
}
