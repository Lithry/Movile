using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour {
    static public ItemFactory instance = null;
    public GameObject itemPrefab;
    private GameObject item;

    void Awake() {
        instance = this;
    }

    public GameObject Create() {
        item = Instantiate(itemPrefab, new Vector3(0, 0.2f, 0), new Quaternion(0, 0, 0, 1));
        return item;
    }

    public void Recycle(GameObject obj) {
        Destroy(obj);
    }
}
