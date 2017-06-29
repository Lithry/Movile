using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private GunController gun;
    private Transform trans;

    public float speed;

    void Start() {
        gun = GetComponentInChildren<GunController>();
        trans = transform;
    }

    void Update() {
        trans.Translate(InputManager.instance.Movement() * (speed * PlayerManager.instance.GetPlussFromLv()) * Time.deltaTime, Space.World);
        trans.rotation = InputManager.instance.LookAt();

        if (InputManager.instance.Fire())
            gun.FireGun();
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy")
        {
            PlayerManager.instance.PlayerDied();
            PlayerFactory.instance.Recycle(gameObject);
        }
        if (collider.tag == "Item")
        {
            gun.ChangeWeapon(collider.GetComponent<Item>().type);
        }
    }
}