using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private PoolObject po;
    private float timer;

    private void OnEnable() {
        timer = 0;
    }
    void Update () {
        timer += Time.deltaTime;

        if (timer > 2)
            End();
        
        transform.Translate(Vector3.forward * 3.5f * Time.deltaTime);
    }

    void End() {
        if (po == null)
            po = GetComponent<PoolObject>();
        PoolManager.instance.Recycle(po, Units.PoolType.Bullet);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy") {
            if (po == null)
                po = GetComponent<PoolObject>();
            PoolManager.instance.Recycle(po, Units.PoolType.Bullet);
        }
    }
}
