using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour {
    static public ZombieFactory instance = null;
    public GameObject zombiePrefab;

    void Awake()
    {
        instance = this;
    }


    public GameObject Create(string type)
    {
        switch (type)
        {
            case "Zombie":
                GameObject zombie = Instantiate(zombiePrefab, new Vector3(0, 0.2f, 0), new Quaternion(0, 0, 0, 1));
                return zombie;
            default:
                return null;
        }
    }

    public void Recycle(GameObject obj)
    {
        Destroy(obj);
    }
}
