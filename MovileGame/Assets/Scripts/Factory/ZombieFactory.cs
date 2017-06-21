using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour {
    static public ZombieFactory instance = null;
    public GameObject zombiePrefab;
    private GameObject zombie;

    void Awake() {
        instance = this;
    }

    public GameObject Create() {
        zombie = Instantiate(zombiePrefab, new Vector3(0, 0.2f, 0), new Quaternion(0, 0, 0, 1));
        return zombie;
    }

    public void Recycle(GameObject obj) {
        Destroy(obj);
    }
}
