using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Units {
    public enum Player {
        Player = 0,
    }

    public struct Level
    {
        public int level;
        public float pluss;
        public int exp;
        public int expToNextLv;
    }

    public enum PoolType
    {
        Bullet = 0,
        Zombie
    }

    public enum Enemigos {
        Zombie = 0,
    }

    public enum Ammo
    {
        Bullets = 0,
        RaylCast
    }
    
    public struct Weapon {
        public Ammo ammoType;
        public int ammo;
        public float shootRate;
        public float reloadTime;

        public Weapon(Ammo type, int cap, float relo, float reca) {
            this.ammoType = type;
            this.ammo = cap;
            this.shootRate = relo;
            this.reloadTime = reca;
        }
    }
    static public Weapon[] weapons = new Weapon[2]
    {
        new Weapon(Ammo.RaylCast, 6, 0.3f ,1.3f), // Gun
        new Weapon(Ammo.RaylCast, 3, 0.6f, 2.4f)  // Shotgun
    };
    public enum Weapons
    {
        Gun = 0,
        Shotgun
    }

    static public float[] weaponReloadTime =
        {   1.3f };

    static public float playerSpeed = 1;

    static public float zombieSpeed = 0.7f;
    static public int zombiePoints = 5;
    static public int zombieExp = 25;
	
}
