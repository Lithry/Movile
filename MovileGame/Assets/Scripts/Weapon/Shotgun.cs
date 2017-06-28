using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    public override void Shoot(Vector3 pos, Vector3 rot)
    {
        for (int i = 0; i < rate; i++)
        {
            randDispersion = rot.y + Random.Range(-dispersion, dispersion);
            rotation.Set(rot.x, randDispersion, rot.z);
            BulletBuilder.instance.Build(Units.Weapons.Shotgun, pos, rotation);
        }
        
        currentAmmo -= 1;
    }
}
