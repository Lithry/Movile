using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilder : MonoBehaviour {
    static public PlayerBuilder instance = null;
    private GameObject obj;
    void Awake() {
        instance = this;
    }

    public GameObject Build(string type, Vector3 pPos, Vector3 pRot) {
        switch (type)
        {
            case "Player":
                obj = PlayerFactory.instance.Create(type);
                PlayerController a = obj.AddComponent<PlayerController>();
                a.speed = 35;
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                return obj;
            default:
                return null;
        }
    }
}
