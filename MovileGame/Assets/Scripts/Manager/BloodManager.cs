using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoBehaviour {
    static public BloodManager instance;
    private GameObject obj;

	void Start () {
        instance = this;
	}
	
	public void CreateBlood(Vector3 pos, Vector3 dir) {
        obj = PoolManager.instance.Spawn(Units.PoolType.Blood);

        obj.transform.position = pos;
        obj.transform.eulerAngles = dir;
    }

    public void Recycle(PoolObject po, Units.PoolType type) {
        PoolManager.instance.Recycle(po, type);
    }
}
