using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {

    private void Start() {
        Invoke("End", 2);
    }
    void Update () {
        transform.Translate(Vector3.forward * 3.5f * Time.deltaTime);
    }

    void End() {
        BulletFactory.instance.Recycle(gameObject);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy") {
            BulletFactory.instance.Recycle(gameObject);
        }
    }
}
