using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance = null;
    private int score;
    
    // Use this for initialization
    void Start() {
        instance = this;
	}
	
	// Update is called once per frame
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
