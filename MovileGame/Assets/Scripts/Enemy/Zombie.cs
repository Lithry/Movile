using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {
    private Vector3 moveTo;

    void Start () {
	}
	
	void Update () {
        moveTo.x = PlayerManager.instance.PlayerPos().x;
        moveTo.y = transform.position.y;
        moveTo.z = PlayerManager.instance.PlayerPos().z;
        transform.LookAt(moveTo);

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
	}
    
    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Bullet") {
            PlayerManager.instance.GetExp(giveExp);
            ScoreManager.instance.AddScore(giveScore);
            ZombieManager.instance.Recycle(gameObject);
        }
    }
}
