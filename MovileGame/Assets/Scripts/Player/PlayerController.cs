using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 lookAt;
    private float angle;
    private GunController gun;
    private int exp;
    

    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody>();
        gun = GetComponentInChildren<GunController>();
    }

    void Update() {
        transform.Translate(InputManager.instance.Movement() * (speed * PlayerManager.instance.GetPlussFromLv()) * Time.deltaTime, Space.World);
        transform.rotation = InputManager.instance.LookAt();

        if (InputManager.instance.Fire())
            gun.FireGun();
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy")
        {
            PlayerManager.instance.PlayerDied();
            PlayerFactory.instance.Recycle(gameObject);
        }
    }
}