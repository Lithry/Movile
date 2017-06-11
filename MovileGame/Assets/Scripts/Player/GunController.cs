using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    private Transform tip;
    private Units.Armas weapon;
    private float[] reload;
    private float reloadCount;

	void Start () {
        tip = transform.FindChild("Tip");
        weapon = Units.Armas.Pistola;
        reload = Units.weaponReloadTime;
        reloadCount = (int)weapon;
        GiveCanvasReloadTime();
    }

    public void FireGun()
    {
        //reloadCount += Time.deltaTime;
        if (Time.time - reloadCount >= (reload[(int)weapon] / PlayerManager.instance.GetPlussFromLv()))
        {
            BulletBuilder.instance.Build(Units.Type.Weapon, weapon, tip.position, tip.eulerAngles);
            reloadCount = Time.time;
            CanvasManager.instance.TimeOfShoot(reloadCount);
        }
    }

    public void ChangeWeapon(Units.Armas obj) {
        weapon = obj;
    }

    private void GiveCanvasReloadTime()
    {
        CanvasManager.instance.WeaponReloadTime(reload[(int)weapon]);
    }
}