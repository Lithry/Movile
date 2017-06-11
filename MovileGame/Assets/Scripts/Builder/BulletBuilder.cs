using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuilder : MonoBehaviour {
    static public BulletBuilder instance = null;
    private GameObject obj;
    
    void Awake () {
        instance = this;
	}
	
    public void Build(Units.Type type, Units.Armas wep, Vector3 pPos, Vector3 pRot) {
        obj = PoolManager.instance.Spawn(type);

        if (obj == null)

        switch (wep) {
            case Units.Armas.Pistola:
                //obj = BulletFactory.instance.Create(wep);
                Pistol a = obj.AddComponent<Pistol>();
                a.ResetTimer();
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
