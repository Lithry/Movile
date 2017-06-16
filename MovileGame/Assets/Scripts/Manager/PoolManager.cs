using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
    static public PoolManager instance = null;

    public GameObject[] poolObjects;
    private Pool[] pools;

    // Use this for initialization
    void Start () {
        instance = this;
        pools = new Pool[poolObjects.Length];
        for (int i = 0; i < poolObjects.Length; i++)  {
            GameObject go = Instantiate(poolObjects[i]);
            pools[i] = go.GetComponent<Pool>();
        }
	}
	
    public GameObject Spawn(Units.PoolType type) {
        switch (type) {
            case Units.PoolType.Bullet:
                return pools[0].Spawn();
        }

        return null;
    }

    public void Recycle(PoolObject po, Units.PoolType type) {
        switch (type) {
            case Units.PoolType.Bullet:
                pools[0].Recycl(po);
                break;
            default:
                break;
        }
    }

}
