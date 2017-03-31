using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 lookAt;
    private float angle;
    private GameObject bullet;

    public float speed;
	
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        Movement();
        Attack();        
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Vector3.right * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }

        // Look at mouse
        lookAt = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = -Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bullet = BulletBuilder.instance.Build("Pistol");
            bullet.transform.position = transform.position;
            bullet.transform.eulerAngles = transform.eulerAngles;
        }
    }
}
