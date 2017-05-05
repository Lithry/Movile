using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 lookAt;
    private float angle;
    private GunController gun;

    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody>();
        gun = GetComponentInChildren<GunController>();
    }

    void Update() {
        rb.AddForce(InputManager.instance.Movement() * speed);
        transform.rotation = InputManager.instance.LookAt();

        if (InputManager.instance.Fire())
            gun.FireGun(Units.Armas.Pistola);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy")
        {
            PlayerManager.instance.PlayerDied();
            PlayerFactory.instance.Recycle(gameObject);
        }
    }
}