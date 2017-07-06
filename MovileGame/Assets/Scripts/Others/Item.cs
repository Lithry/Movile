using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    private Units.Weapons type;
    private PoolObject po;
    private float timer;

    private void OnEnable() {
        timer = 0;
    }

    private void Update() {
        timer += Time.deltaTime;

        if (timer > 45)
            Recycl();
    }

    public void SetItemType(Units.Weapons iType) {
        type = iType;

        if (po == null)
            po = GetComponent<PoolObject>();
    }

    public Units.Weapons GetItemType() {
        return type;
    }

    public void Recycl() {
        PoolManager.instance.Recycle(po, Units.PoolType.Items);
    }
}
