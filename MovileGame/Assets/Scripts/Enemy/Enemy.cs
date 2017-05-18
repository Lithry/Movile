using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    protected float speed = 0;
    protected int giveScore = 0;
    protected int giveExp = 0;
	
    public void SetSpeed(float spd) {
        speed = spd;
    }

    public void GiveScore(int score) {
        giveScore = score;
    }

    public void GiveExp(int exp) {
        giveExp = exp;
    }
}
