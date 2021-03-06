﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilder : MonoBehaviour {
    static public PlayerBuilder instance = null;
    public GameObject blood;
    private GameObject obj;

    void Awake() {
        instance = this;
    }

    public GameObject Build(Units.Player type, Vector3 pPos, Vector3 pRot) {
        switch (type) {
            case Units.Player.Player:
                obj = PlayerFactory.instance.Create(type);
                PlayerController a = obj.GetComponent<PlayerController>();
                a.SetSpeed(Units.playerSpeed);
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                return obj;
            default:
                return null;
        }
    }
}
