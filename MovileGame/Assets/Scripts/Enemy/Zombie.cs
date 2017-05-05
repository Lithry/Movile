using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {
    private Rigidbody rb;
    private Vector3 moveTo;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        moveTo.x = PlayerManager.instance.PlayerPos().x;
        moveTo.y = transform.position.y;
        moveTo.z = PlayerManager.instance.PlayerPos().z;
        transform.LookAt(moveTo);

        rb.AddForce(transform.forward * speed);
	}
    
    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Bullet") {
            ScoreManager.instance.AddScore(giveScore);
            ZombieManager.instance.Recycle(gameObject);
        }
    }
}
