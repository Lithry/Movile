using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBloodFactory : MonoBehaviour {
    static public ZombieBloodFactory instance = null;
    public GameObject prefab;

    void Start () {
        instance = this;
    }

    public GameObject Create() {
        GameObject blood = Instantiate(prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
        return blood;
    }

    public void Recycle(GameObject obj) {
        Destroy(obj);
    }
}
