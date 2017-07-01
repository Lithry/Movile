using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    private Transform tip;
    private Weapon weapon;
    private Units.Weapons wep;
    private float[] reload;
    private float reloadCount;


    void Start () {
        tip = transform.FindChild("Tip");
        weapon = gameObject.AddComponent<Pistol>();
        wep = Units.Weapons.Pistol;
        weapon.SetValues(Units.weapons[(int)wep].ammo, Units.weapons[(int)wep].shootRate, Units.weapons[(int)wep].shootSoeed, Units.weapons[(int)wep].dispersion, Units.weapons[(int)wep].reloadTime);

        reloadCount = 0;

        CanvasManager.instance.WeaponReloadTime(weapon.GetShootSpeed());
        CanvasManager.instance.SetAmmo(weapon.GetAmmo());
        CanvasManager.instance.SetCurrentAmmo(weapon.GetCurrentAmmo());
    }

    public void FireGun()
    {
        if (weapon.GetCurrentAmmo() > 0) {
            if (Time.time - reloadCount >= weapon.GetShootSpeed() / PlayerManager.instance.GetPlussFromLv() && InputManager.instance.Fire()) {
                weapon.Shoot(tip.position, tip.eulerAngles);
                reloadCount = Time.time;
                CanvasManager.instance.TimeOfShoot(reloadCount);
                CanvasManager.instance.SetCurrentAmmo(weapon.GetCurrentAmmo());
                if (weapon.GetCurrentAmmo() == 0)
                    CanvasManager.instance.WeaponReloadTime(weapon.GetReloadTime());
            }
        }
        else if (weapon.GetCurrentAmmo() < 1)
        {
            if ((Time.time - reloadCount >= weapon.GetReloadTime() / PlayerManager.instance.GetPlussFromLv())) {
                weapon.Reload();
                CanvasManager.instance.WeaponReloadTime(weapon.GetShootSpeed());
                reloadCount = Time.time;
                CanvasManager.instance.TimeOfShoot(reloadCount);
                CanvasManager.instance.SetCurrentAmmo(weapon.GetCurrentAmmo());
            }
        }
    }

    public void ChangeWeapon(Units.Weapons obj) {
        switch (obj)
        {
            case Units.Weapons.Pistol:
                Destroy(weapon);
                weapon = gameObject.AddComponent<Pistol>();
                break;
            case Units.Weapons.Shotgun:
                Destroy(weapon);
                weapon = gameObject.AddComponent<Shotgun>();
                break;
            case Units.Weapons.MachineGun:
                Destroy(weapon);
                weapon = gameObject.AddComponent<MachineGun>();
                break;
            default:
                break;
        }

        weapon.SetValues(Units.weapons[(int)obj].ammo, Units.weapons[(int)obj].shootRate, Units.weapons[(int)obj].shootSoeed, Units.weapons[(int)obj].dispersion, Units.weapons[(int)obj].reloadTime);
        CanvasManager.instance.SetAmmo(weapon.GetAmmo());
        CanvasManager.instance.SetCurrentAmmo(weapon.GetCurrentAmmo());
    }
}