using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBuilder : MonoBehaviour {
    static public ZombieBuilder instance = null;
    private GameObject obj;

    void Awake() {
        instance = this;
    }

    public GameObject Build(Units.Enemigos type, Vector3 pPos, Vector3 pRot) {
        obj = PoolManager.instance.Spawn(Units.PoolType.Zombie);

        switch (type) {
            case Units.Enemigos.Zombie:
                Zombie a = obj.GetComponent<Zombie>();
                a.SetSpeed(Units.zombieSpeed);
                a.GiveScore(Units.zombiePoints);
                a.GiveExp(Units.zombieExp);
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                return obj;
            default:
                return null;
        }
    }
}
