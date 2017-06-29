using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    private Transform tip;
    private Weapon wep;
    private Units.Weapons weapon;
    private float[] reload;
    private float reloadCount;


    void Start () {
        tip = transform.FindChild("Tip");
        wep = gameObject.AddComponent<MachineGun>();
        weapon = Units.Weapons.MachineGun;
        wep.SetValues(Units.weapons[(int)weapon].ammo, Units.weapons[(int)weapon].shootRate, Units.weapons[(int)weapon].shootSoeed, Units.weapons[(int)weapon].dispersion, Units.weapons[(int)weapon].reloadTime);

        reloadCount = 0;

        CanvasManager.instance.WeaponReloadTime(wep.GetShootSpeed());
        CanvasManager.instance.SetAmmo(wep.GetAmmo());
        CanvasManager.instance.SetCurrentAmmo(wep.GetCurrentAmmo());
    }

    public void FireGun()
    {
        if (wep.GetCurrentAmmo() > 0) {
            if (Time.time - reloadCount >= wep.GetShootSpeed() / PlayerManager.instance.GetPlussFromLv()) {
                wep.Shoot(tip.position, tip.eulerAngles);
                reloadCount = Time.time;
                CanvasManager.instance.TimeOfShoot(reloadCount);
                CanvasManager.instance.SetCurrentAmmo(wep.GetCurrentAmmo());
                if (wep.GetCurrentAmmo() == 0)
                    CanvasManager.instance.WeaponReloadTime(wep.GetReloadTime());
            }
        }
        else if (wep.GetCurrentAmmo() < 1)
        {
            if ((Time.time - reloadCount >= wep.GetReloadTime() / PlayerManager.instance.GetPlussFromLv())) {
                wep.Reload();
                CanvasManager.instance.WeaponReloadTime(wep.GetShootSpeed());
                reloadCount = Time.time;
                CanvasManager.instance.TimeOfShoot(reloadCount);
                CanvasManager.instance.SetCurrentAmmo(wep.GetCurrentAmmo());
            }
        }
    }

    public void ChangeWeapon(Units.Weapons obj) {
        switch (obj)
        {
            case Units.Weapons.Pistol:
                Destroy(wep);
                wep = gameObject.AddComponent<Pistol>();
                break;
            case Units.Weapons.Shotgun:
                Destroy(wep);
                wep = gameObject.AddComponent<Shotgun>();
                break;
            case Units.Weapons.MachineGun:
                Destroy(wep);
                wep = gameObject.AddComponent<MachineGun>();
                break;
            default:
                break;
        }

        wep.SetValues(Units.weapons[(int)obj].ammo, Units.weapons[(int)obj].shootRate, Units.weapons[(int)obj].shootSoeed, Units.weapons[(int)obj].dispersion, Units.weapons[(int)obj].reloadTime);
        CanvasManager.instance.SetAmmo(wep.GetAmmo());
        CanvasManager.instance.SetCurrentAmmo(wep.GetCurrentAmmo());
    }
}