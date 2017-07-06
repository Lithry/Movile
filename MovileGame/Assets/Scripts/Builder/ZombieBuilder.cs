using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBuilder : MonoBehaviour {
    static public ZombieBuilder instance = null;
    private GameObject obj;
    private Vector3 scale;

    void Awake() {
        instance = this;
    }

    public GameObject Build(Units.Enemigos type, Vector3 pPos, Vector3 pRot) {
        obj = PoolManager.instance.Spawn(Units.PoolType.Zombie);
        Zombie z = obj.GetComponent<Zombie>();

        switch (type) {
            case Units.Enemigos.Zombie:
                z.SetHP(4);
                z.SetSpeed(Units.zombieSpeed);
                z.GiveScore(Units.zombiePoints);
                z.GiveExp(Units.zombieExp);
                scale.Set(0.2f, 0.2f, 0.2f);
                obj.transform.localScale = scale;
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                return obj;
            case Units.Enemigos.BigZombie:
                z.SetHP(35);
                z.SetSpeed(Units.zombieBossSpeed);
                z.GiveScore(Units.zombieBossPoints);
                z.GiveExp(Units.zombieBossExp);
                scale.Set(0.4f, 0.4f, 0.4f);
                obj.transform.localScale = scale;
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                return obj;
            default:
                return null;
        }
    }
}
