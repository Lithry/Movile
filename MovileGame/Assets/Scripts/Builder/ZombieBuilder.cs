using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBuilder : MonoBehaviour {
    static public ZombieBuilder instance = null;
    private GameObject obj;


    void Awake()
    {
        instance = this;
    }

    public GameObject Build(string type, Vector3 pPos, Vector3 pRot)
    {
        switch (type)
        {
            case "Zombie":
                obj = ZombieFactory.instance.Create(type);
                Zombie a = obj.AddComponent<Zombie>();
                a.SetSpeed(0.7f);
                a.GiveScore(5);
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                return obj;
            default:
                return null;
        }
    }
}
