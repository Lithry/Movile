using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    private Rigidbody rb;

    private float speed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(new Vector3(ZombieManager.instance.PlayerPos().x, transform.position.y, ZombieManager.instance.PlayerPos().z));
        transform.LookAt(ZombieManager.instance.PlayerPos());

        rb.velocity = transform.forward * speed;
	}

    public void SetSpeed(float spd) {
        speed = spd;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet") {
            ZombieFactory.instance.Recycle(gameObject);
        }
    }
}
