using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 moveTo;
    private float speed;
    private int giveScore = 0;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        moveTo.x = PlayerManager.instance.PlayerPos().x;
        moveTo.y = transform.position.y;
        moveTo.z = PlayerManager.instance.PlayerPos().z;
        transform.LookAt(moveTo);

        rb.velocity = transform.forward * speed;
	}

    public void SetSpeed(float spd) {
        speed = spd;
    }

    public void GiveScore(int give)
    {
        giveScore = give;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet") {
            ScoreManager.instance.AddScore(giveScore);
            ZombieManager.instance.Recycle(gameObject);
        }
    }
}
