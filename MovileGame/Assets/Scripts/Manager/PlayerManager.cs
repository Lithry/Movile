using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    static public PlayerManager instance = null;
    private GameObject player;

    // Use this for initialization
    void Start() {
        instance = this;
        player = PlayerBuilder.instance.Build("Player", new Vector3(0, 0.01f, 0), new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update() {

    }

    public Vector3 PlayerPos() {
        return player.transform.position;
    }
}
