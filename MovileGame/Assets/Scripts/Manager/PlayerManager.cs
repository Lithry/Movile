using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    static public PlayerManager instance = null;
    private GameObject player = null;
    private Vector3 playerLastPosition;
    private Units.Level playerLv;

    void Start() {
        instance = this;
        playerLv.level = 1;
        playerLv.pluss = 1;
        playerLv.expToNextLv = 100;
    }

    void Update() {
        if (player != null)
            playerLastPosition = player.transform.position;

        if (playerLv.exp >= playerLv.expToNextLv)
            LevelUp();
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

    public void GetExp(int ex) {
        playerLv.exp += ex;
    }

    public void LevelUp() {
        playerLv.level += 1;
        playerLv.pluss += 0.1f;
        playerLv.exp = 0;
        playerLv.expToNextLv *= 2;
    }

    public void ResetLv() {
        playerLv.level = 1;
        playerLv.pluss = 1;
        playerLv.exp = 0;
        playerLv.expToNextLv = 100;
    }

    public int Level() {
        return playerLv.level;
    }

    public float GetPlussFromLv() {
        return playerLv.pluss;
    }
}
