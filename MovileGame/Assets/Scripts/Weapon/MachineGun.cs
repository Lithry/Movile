using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon {

    public override void Shoot(Vector3 pos, Vector3 rot)
    {
        randDispersion = rot.y + Random.Range(-dispersion, dispersion);
        rotation.Set(rot.x, randDispersion, rot.z);
        BulletBuilder.instance.Build(Units.Weapons.MachineGun, pos, rotation);
        currentAmmo -= 1;
    }
}
