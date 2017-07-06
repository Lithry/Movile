using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuilder : MonoBehaviour {
    static public ItemBuilder instance = null;
    private Item it;
    private Vector3 iPos;
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
                it.SetPoints(30);
                mesh.material = pistolMaterial;
                break;
            case Units.Weapons.Shotgun:
                it.SetPoints(50);
                mesh.material = ShotgunMaterial;
                break;
            case Units.Weapons.MachineGun:
                it.SetPoints(60);
                mesh.material = machineGunMaterial;
                break;
        }

        iPos = pPos;
        iPos.y = 0.15f;
        obj.transform.position = iPos;
        obj.transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
