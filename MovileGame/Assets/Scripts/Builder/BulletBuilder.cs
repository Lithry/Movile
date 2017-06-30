using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuilder : MonoBehaviour {
    static public BulletBuilder instance = null;
    private Bullet bul;
    private GameObject obj;
    
    void Awake () {
        instance = this;
	}
	
    public void Build(Units.Weapons wep, Vector3 pPos, Vector3 pRot) {
        obj = PoolManager.instance.Spawn(Units.PoolType.Bullet);
        bul = obj.GetComponent<Bullet>();

        switch (wep) {
            case Units.Weapons.Pistol:
                bul.SetRecycleTime(2);
                bul.SetSpeed(5);
                bul.SetPircePower(1);
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                break;
            case Units.Weapons.Shotgun:
                bul.SetRecycleTime(0.15f);
                bul.SetSpeed(7);
                bul.SetPircePower(3);
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                break;
            case Units.Weapons.MachineGun:
                bul.SetRecycleTime(1f);
                bul.SetSpeed(6);
                bul.SetPircePower(1);
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                break;
            default:
                break;
        }
    }
}
