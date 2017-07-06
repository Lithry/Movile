using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    static public ItemManager instance = null;
    public GameObject prefab;

    void Start () {
        instance = this;
    }

    public void MakeItem(Vector3 pos) {
        ItemBuilder.instance.Build(RandormWeapon(), pos);
    }

    private Units.Weapons RandormWeapon()
    {
        float max = (float)Units.Weapons.MAX * 0.1f;
        int wep = (int)(Random.Range(0.0f, max) * 10);

        switch (wep)
        {
            case (int)Units.Weapons.Pistol:
                return Units.Weapons.Pistol;
            case (int)Units.Weapons.Shotgun:
                return Units.Weapons.Shotgun;
            case (int)Units.Weapons.MachineGun:
                return Units.Weapons.MachineGun;
            default:
                return Units.Weapons.Pistol;
        }
    }

    public void Recycle(GameObject obj) {
        obj.GetComponent<Item>().Recycl();
    }
}
