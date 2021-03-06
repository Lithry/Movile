﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour {
    static public BulletFactory instance = null;
    public GameObject prefab;

    void Awake () {
        instance = this;
	}
	
    public GameObject Create() {
        GameObject bullet = Instantiate(prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
        return bullet;
    }

    public void Recycle(GameObject obj) {
        Destroy(obj);
    }
}
