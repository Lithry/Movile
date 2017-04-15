using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {
    static public ZombieManager instance = null;
    private GameObject player;

    public float respawnDelay;
    private float respawn;

    // Use this for initialization
    void Start () {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        respawnDelay = 5;
    }
	
	// Update is called once per frame
	void Update () {
        respawn += Time.deltaTime;

        if (respawn > respawnDelay)
        {
            ZombieBuilder.instance.Build("Zombie", new Vector3(0, 0.3f, 0), new Vector3(0, 0, 0));
            respawn = 0;
            respawnDelay = Random.Range(0.5f, 4.0f);
        }
	}

    public Vector3 PlayerPos() {
        return player.transform.position;
    }
}
