using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 pos;
    [Range(1, 5)]
    public float distanceToPlayer;

    private void Start() {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    void Update () {
        pos.Set(PlayerManager.instance.PlayerPos().x, PlayerManager.instance.PlayerPos().y + distanceToPlayer, PlayerManager.instance.PlayerPos().z);
        transform.position = pos;
	}
}
