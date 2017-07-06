using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {
    private PoolObject po;
    private float delay;
	// Use this for initialization
	void OnEnable () {
        delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
        delay += Time.deltaTime;

        if (delay > 1)
            End();
	}

    void End()
    {
        if (po == null)
            po = GetComponent<PoolObject>();
        BloodManager.instance.Recycle(po, Units.PoolType.Blood);
    }
}
