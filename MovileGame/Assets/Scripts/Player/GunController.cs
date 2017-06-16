using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    private Transform tip;
    private Units.Weapons weapon;
    private float[] reload;
    private float reloadCount;

	void Start () {
        tip = transform.FindChild("Tip");
        weapon = Units.Weapons.Gun;
        reload = Units.weaponReloadTime;
        reloadCount = (int)weapon;
        GiveCanvasReloadTime();
    }

    public void FireGun()
    {
        if (Time.time - reloadCount >= (reload[(int)weapon] / PlayerManager.instance.GetPlussFromLv()))
        {
            BulletBuilder.instance.Build(weapon, tip.position, tip.eulerAngles);
            reloadCount = Time.time;
            CanvasManager.instance.TimeOfShoot(reloadCount);
        }
    }

    public void ChangeWeapon(Units.Weapons obj) {
        weapon = obj;
    }

    private void GiveCanvasReloadTime()
    {
        CanvasManager.instance.WeaponReloadTime(reload[(int)weapon]);
    }
}