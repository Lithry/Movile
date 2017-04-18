using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {
    static public ZombieManager instance = null;
    private GameObject player;

    private float respawnDelay;
    private float respawn;

    // Use this for initialization
    void Start () {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        respawnDelay = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Respawn();        
	}

    private void Respawn() {
        respawn += Time.deltaTime;

        if (respawn > respawnDelay)
        {
            int angle = (int)Random.Range(1.00f, 360.99f);
            Vector3 respawnPos = new Vector3(Mathf.Cos(angle) * 3, 0.3f, Mathf.Sin(angle) * 3);

            ZombieBuilder.instance.Build("Zombie", respawnPos + PlayerPos(), new Vector3(0, 0, 0));
            respawn = 0;
            respawnDelay = Random.Range(0.5f, 2.0f);
        }
    }

    public Vector3 PlayerPos() {
        return player.transform.position;
    }
}
