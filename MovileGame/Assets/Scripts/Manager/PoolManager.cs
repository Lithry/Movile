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

        pools = new Pool[poolObjects.Length + 1];

        for (int i = 0; i < poolObjects.Length; i++)
        {
            Instantiate(poolObjects[i]);
            pools[i] = poolObjects[i].GetComponent<Pool>();
        }
	}
	
    public GameObject Spawn(Units.Type type)
    {
        switch (type)
        {
            case Units.Type.Weapon:
                return pools[0].Spawn();
            case Units.Type.Enemies:
                return pools[1].Spawn();
        }

        return null;
    }

    public void Recycle(PoolObject po, Units.Type type)
    {
        switch (type)
        {
            case Units.Type.Weapon:
                pools[0].Recycl(po);
                break;
            case Units.Type.Enemies:
                break;
            default:
                break;
        }
    }

}
