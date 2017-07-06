using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuilder : MonoBehaviour {
    static public ItemBuilder instance = null;
    private Item it;
    private GameObject obj;
    private MeshRenderer mesh;
    public Material pistolMaterial;
    public Material ShotgunMaterial;
    public Material machineGunMaterial;

    void Awake()
    {
        instance = this;
    }

    public void Build(Units.Weapons wep, Vector3 pPos) {
        obj = PoolManager.instance.Spawn(Units.PoolType.Items);
        it = obj.GetComponent<Item>();
        it.SetItemType(wep);
        mesh = obj.GetComponent<MeshRenderer>();
        switch (wep)
        {
            case Units.Weapons.Pistol:
                mesh.material = pistolMaterial;
                break;
            case Units.Weapons.Shotgun:
                mesh.material = ShotgunMaterial;
                break;
            case Units.Weapons.MachineGun:
                mesh.material = machineGunMaterial;
                break;
        }

        obj.transform.position = pPos;
    }
}
