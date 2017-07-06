using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private GunController gun;
    private Transform trans;

    private float speed;
    public ParticleSystem blood;

    void Start() {
        gun = GetComponentInChildren<GunController>();
        trans = transform;
        blood.Stop();
    }

    void Update() {
        trans.Translate(InputManager.instance.Movement() * (speed * PlayerManager.instance.GetPlussFromLv()) * Time.deltaTime, Space.World);
        trans.rotation = InputManager.instance.LookAt();

        gun.FireGun();
    }

    public void SetSpeed(float sSpeed) {
        speed = sSpeed;
    }


    IEnumerator Dead()
    {
        blood.Play();
        yield return new WaitForSeconds(2);
        PlayerFactory.instance.Recycle(gameObject);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy")
        {
            PlayerManager.instance.PlayerDied();
            StartCoroutine(Dead());
        }
        if (collider.tag == "Item")
        {
            Item it = collider.GetComponent<Item>();
            gun.ChangeWeapon(it.GetItemType());
            ScoreManager.instance.AddScore(it.GetPoint());
            ItemManager.instance.Recycle(collider.gameObject);
        }
    }
}