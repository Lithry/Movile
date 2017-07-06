using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {
    public int count = 10;
    public Units.PoolType type;
    private List<PoolObject> objects = new List<PoolObject>();

	void Start () {
        for (int i = 0; i < count; i++) {
            PoolObject po = Create();
            po.gameObject.SetActive(false);
            objects.Add(po);
        }
	}
	

	public PoolObject Create () {
        GameObject go = null;
        switch (type) {
            case Units.PoolType.Bullet:
                go = BulletFactory.instance.Create();
                break;
            case Units.PoolType.Zombie:
                go = ZombieFactory.instance.Create();
                break;
            case Units.PoolType.Blood:
                go = ZombieBloodFactory.instance.Create();
                break;
            case Units.PoolType.Items:
                go = ItemFactory.instance.Create();
                break;
        }

        PoolObject po = go.AddComponent<PoolObject>();
        po.SetPool(this);
        return po;
    }

    public GameObject Spawn() {
        PoolObject po = null;

        if (objects.Count > 0) {
            po = objects[0];
            po.gameObject.SetActive(true);
            objects.RemoveAt(0);

            return po.gameObject;
        }
        else
            return Create().gameObject;


    }

    public void Recycl(PoolObject po) {
        po.gameObject.SetActive(false);
        objects.Add(po);
    }
}
