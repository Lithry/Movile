using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected int ammo;
    protected int currentAmmo;
    protected int rate;
    protected float shootSpeed;
    protected float dispersion;
    protected float reloadTime;

    protected Vector3 rotation;
    protected float randDispersion;

    public virtual void Shoot(Vector3 pos, Vector3 rot) { }

    public void SetValues(int sAmmo, int sRate, float sShootSpeed, float sDispersion, float sReloadTime) {
        ammo = currentAmmo = sAmmo;
        rate = sRate;
        shootSpeed = sShootSpeed;
        dispersion = sDispersion;
        reloadTime = sReloadTime;
    }

    public void Reload() {
        currentAmmo = ammo;
    }

    public int GetAmmo() {
        return ammo;
    }

    public int GetCurrentAmmo() {
        return currentAmmo;
    }

    public float GetShootSpeed() {
        return shootSpeed;
    }

    public float GetRateOfShoot() {
        return rate;
    }

    public float GetReloadTime() {
        return reloadTime;
    }
}
