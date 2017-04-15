using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour {
    static public BulletFactory instance = null;
    public GameObject bulletCubePrefab;

    void Awake () {
        instance = this;
	}
	

    public GameObject Create(string type)
    {
        switch (type)
        {
            case "Pistol":
                GameObject bullet = Instantiate(bulletCubePrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
                return bullet;
            default:
                return null;
        }
    }

    public void Recycle(GameObject obj)
    {
        Destroy(obj);
    }
}
