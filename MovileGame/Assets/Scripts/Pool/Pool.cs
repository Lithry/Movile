using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {
    public GameObject prefab;
    public int count = 10;

    public Units.Type type;

    private List<PoolObject> objects = new List<PoolObject>();
	// Use this for initialization
	void Start () {
        for (int i = 0; i < count; i++)
        {
            PoolObject po = Create();
            po.gameObject.SetActive(false);
            objects.Add(po);
        }
	}
	
	// Update is called once per frame
	public PoolObject Create () {
        GameObject go = null;
        switch (type)
        {
            case Units.Type.Weapon:
                go = BulletFactory.instance.Create();
                break;
            case Units.Type.Enemies:
                //go = ZombieFactory.instance.Create();
                break;
        }

        PoolObject po = go.AddComponent<PoolObject>();
        po.SetPool(this);
        return po;
    }

    public GameObject Spawn()
    {
        PoolObject po = null;

        if (objects.Count > 0)
        {
            po = objects[0];
            po.gameObject.SetActive(true);
            objects.RemoveAt(0);

            return po.gameObject;
        }
        else
            return Create().gameObject;


    }

    public void Recycl(PoolObject po)
    {
        po.gameObject.SetActive(false);
        objects.Add(po);
    }
}
