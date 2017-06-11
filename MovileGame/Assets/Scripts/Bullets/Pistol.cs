using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {
    private PoolObject po;
    private float timer;

    private void Start() {
        po = GetComponent<PoolObject>();
        timer = 0;
        //Invoke("End", 2);
    }
    void Update () {
        timer += Time.deltaTime;

        if (timer > 2)
            End();

        transform.Translate(Vector3.forward * 3.5f * Time.deltaTime);
    }

    public void ResetTimer()
    {
        timer = 0;
    }

    void End() {
        PoolManager.instance.Recycle(po, Units.Type.Weapon);
        //BulletFactory.instance.Recycle(gameObject);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy") {
            PoolManager.instance.Recycle(po, Units.Type.Weapon);
            //BulletFactory.instance.Recycle(gameObject);
        }
    }
}
