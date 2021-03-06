﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private PoolObject po;
    private float speed;
    private int dmg;
    private int pirce;
    private float timerForRecycle;
    private float timer;

    private void OnEnable() {
        timer = 0;
    }
    void Update () {
        timer += Time.deltaTime;

        if (timer > timerForRecycle)
            End();
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetSpeed(float spd)
    {
        speed = spd;
    }

    public void SetPircePower(int pow)
    {
        pirce = pow;
    }

    public void SetRecycleTime(float t) {
        timerForRecycle = t;
    }

    void End() {
        if (po == null)
            po = GetComponent<PoolObject>();
        PoolManager.instance.Recycle(po, Units.PoolType.Bullet);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy") {
            
            if (pirce > 1)
                pirce -= 1;
            else {
                if (po == null)
                    po = GetComponent<PoolObject>();

                PoolManager.instance.Recycle(po, Units.PoolType.Bullet);
            }
        }
    }
}
