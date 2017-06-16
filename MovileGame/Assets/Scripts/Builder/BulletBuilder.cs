using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuilder : MonoBehaviour {
    static public BulletBuilder instance = null;
    private GameObject obj;
    
    void Awake () {
        instance = this;
	}
	
    public void Build(Units.Weapons wep, Vector3 pPos, Vector3 pRot) {
        obj = PoolManager.instance.Spawn(Units.PoolType.Bullet);

        switch (wep) {
            case Units.Weapons.Gun:
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                
                //return obj;
                break;
            default:
                //return null;
                break;
        }
    }
}
