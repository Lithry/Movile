using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    static public PlayerManager instance = null;
    private GameObject player = null;
    private Vector3 playerLastPosition;

    void Start() {
        instance = this;
    }

    void Update() {
        if (player != null)
            playerLastPosition = player.transform.position;
    }

    public void NewPlayer() {
        player = PlayerBuilder.instance.Build(Units.Player.Player, new Vector3(0, 0.01f, 0), new Vector3(0, 0, 0));
    }

    public void PlayerDied() {
        player = null;
    }

    public bool PlayerAlive() {
        return (player != null) ? true : false;
    }

    public Vector3 PlayerPos() {
        return (player != null) ? player.transform.position : playerLastPosition;
    }
}
