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
        switch (type) {
            case Units.Enemigos.Zombie:
                obj = ZombieFactory.instance.Create(type);
                Zombie a = obj.AddComponent<Zombie>();
                a.SetSpeed(Units.zombieSpeed);
                a.GiveScore(Units.zombiePoints);
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                return obj;
            default:
                return null;
        }
    }
}
