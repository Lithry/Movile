using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //private ControlsManager controls;
    private Rigidbody rb;
    private Vector3 lookAt;
    private float angle;
    private GunController gun;

    public float speed;
	
	void Start () {
        //controls = GameObject.Find("ControlsManager").GetComponent<ControlsManager>();
        rb = GetComponent<Rigidbody>();
        gun = GetComponentInChildren<GunController>();
	}
	
	void Update () {
        Movement();
        Attack();        
    }

    void Movement()
    {
        if (ControlsManager.instance.UpBottom())
        {
            rb.AddForce(Vector3.forward * speed);
        }

        if (ControlsManager.instance.LeftBottom())
        {
            rb.AddForce(-Vector3.right * speed);
        }

        if (ControlsManager.instance.DownBottom())
        {
            rb.AddForce(-Vector3.forward * speed);
        }

        if (ControlsManager.instance.RightBottom())
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
        if (ControlsManager.instance.FireBottom()) {
            gun.FireGun("Pistol");
            
        }
    }
}
