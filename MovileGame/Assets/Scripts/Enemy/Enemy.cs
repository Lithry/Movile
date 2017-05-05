using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    protected float speed;
    protected int giveScore = 0;
	
    public void SetSpeed(float spd) {
        speed = spd;
    }

    public void GiveScore(int give) {
        giveScore = give;
    }
}
