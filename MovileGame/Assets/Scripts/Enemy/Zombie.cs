using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {
    private Vector3 moveTo;
    private PoolObject po;
    private Transform trans;

    void Start () {
        trans = transform;
	}
	
	void Update () {
        moveTo.x = PlayerManager.instance.PlayerPos().x;
        moveTo.y = transform.position.y;
        moveTo.z = PlayerManager.instance.PlayerPos().z;
        trans.LookAt(moveTo);

        trans.Translate(trans.forward * speed * Time.deltaTime, Space.World);
	}
    
    public void Hit() {
        PlayerManager.instance.GetExp(giveExp);
        ScoreManager.instance.AddScore(giveScore);
        if (po == null)
            po = GetComponent<PoolObject>();
        ZombieManager.instance.Recycle(po, gameObject);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Bullet") {
            Vector3 dir = trans.position - PlayerManager.instance.PlayerPos();
            Vector3 direc = dir / dir.magnitude;
            //float angle = -Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //Quaternion a = Quaternion.AngleAxis(angle, Vector3.up);
            BloodManager.instance.CreateBlood(trans.position, direc);
            if (hp > 1) {
                hp -= 1;
            }
            else {
                PlayerManager.instance.GetExp(giveExp);
                ScoreManager.instance.AddScore(giveScore);
                if (po == null)
                    po = GetComponent<PoolObject>();
                ZombieManager.instance.Recycle(po, gameObject);
            }
        }
    }
}
