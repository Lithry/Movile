using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    private Transform tip;
    private Units.Weapons weapon;
    private float[] reload;
    private float reloadCount;

    private Units.Ammo ammoType;
    private int ammo;
    private int currentAmmo;
    private float shootRate;
    private float rechargeTime;


    void Start () {
        tip = transform.FindChild("Tip");
        
        weapon = Units.Weapons.Gun;
        
        ammoType = Units.weapons[(int)weapon].ammoType;
        ammo = Units.weapons[(int)weapon].ammo;
        currentAmmo = ammo;
        shootRate = Units.weapons[(int)weapon].shootRate;
        rechargeTime = Units.weapons[(int)weapon].reloadTime;

        reloadCount = 0;

        //GiveCanvasReloadTime();
    }

    public void FireGun()
    {
        if (currentAmmo > 0) {
            if (Time.time - reloadCount >= shootRate / PlayerManager.instance.GetPlussFromLv()) {
                BulletBuilder.instance.Build(weapon, tip.position, tip.eulerAngles);
                currentAmmo -= 1;
                reloadCount = Time.time;
                CanvasManager.instance.TimeOfShoot(reloadCount);
                CanvasManager.instance.WeaponReloadTime(shootRate);
            }
        }
        else if (currentAmmo <= 0)
        {
            if ((Time.time - reloadCount >= rechargeTime / PlayerManager.instance.GetPlussFromLv())) {
                currentAmmo = ammo;
                CanvasManager.instance.WeaponReloadTime(rechargeTime);
                reloadCount = Time.time;
                CanvasManager.instance.TimeOfShoot(reloadCount);
            }
        }

        /*if (Time.time - reloadCount >= (reload[(int)weapon] / PlayerManager.instance.GetPlussFromLv()))
        {
            BulletBuilder.instance.Build(weapon, tip.position, tip.eulerAngles);
            reloadCount = Time.time;
            CanvasManager.instance.TimeOfShoot(reloadCount);
        }*/
    }

    public void ChangeWeapon(Units.Weapons obj) {
        weapon = obj;
        ammo = Units.weapons[(int)weapon].ammo;
        currentAmmo = ammo;
        shootRate = Units.weapons[(int)weapon].shootRate;
        rechargeTime = Units.weapons[(int)weapon].reloadTime;
    }

    private void GiveCanvasReloadTime()
    {
        CanvasManager.instance.WeaponReloadTime(reload[(int)weapon]);
    }
}