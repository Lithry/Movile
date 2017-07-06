using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {
    static public ZombieManager instance = null;
    private float respawnDelay;
    private float respawn;

    private float bossesRespawn;
    private float bossRespawnDelay;

    private List<GameObject> enemies;

    void Start() {
        instance = this;
        enemies = new List<GameObject>();
    }
	
	void Update () {
        Respawn();        
	}

    private void Respawn() {
        if (PlayerManager.instance.PlayerAlive()) {
            respawn += Time.deltaTime;
            bossesRespawn += Time.deltaTime;

            if (respawn > respawnDelay) {
                int angle = (int)Random.Range(1.00f, 360.99f);
                Vector3 respawnPos = new Vector3(Mathf.Cos(angle) * 3, 0.3f, Mathf.Sin(angle) * 3);

                enemies.Add(ZombieBuilder.instance.Build(Units.Enemigos.Zombie, respawnPos + PlayerManager.instance.PlayerPos(), new Vector3(0, 0, 0)));
                respawn = 0;
                respawnDelay = Random.Range(0.5f / PlayerManager.instance.GetPlussFromLv(), 2.0f / PlayerManager.instance.GetPlussFromLv());
            }

            if (bossesRespawn > bossRespawnDelay) {
                int angle = (int)Random.Range(1.00f, 360.99f);
                Vector3 respawnPos = new Vector3(Mathf.Cos(angle) * 3, 0.3f, Mathf.Sin(angle) * 3);

                enemies.Add(ZombieBuilder.instance.Build(Units.Enemigos.BigZombie, respawnPos + PlayerManager.instance.PlayerPos(), new Vector3(0, 0, 0)));
                bossesRespawn = 0;
                bossRespawnDelay = Random.Range(20f / PlayerManager.instance.GetPlussFromLv(), 100f / PlayerManager.instance.GetPlussFromLv());
            }
        }
    }

    public void Restart() {
        respawn = 0;
        respawnDelay = 0;
        bossesRespawn = 0;
        bossRespawnDelay = 20;
    }

    public void Recycle(PoolObject po, GameObject obj) {
        if (enemies.Contains(obj))
            enemies.Remove(obj);

        PoolManager.instance.Recycle(po, Units.PoolType.Zombie);
    }

    public void RecycleAll() {
        for (int i = 0; i < enemies.Count; i++) {
            PoolObject po = enemies[i].GetComponent<PoolObject>();
            PoolManager.instance.Recycle(po, Units.PoolType.Zombie);
        }
        enemies.Clear();        
    }
}
