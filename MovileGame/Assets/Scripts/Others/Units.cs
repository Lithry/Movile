using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Units {
    public enum Player {
        Player = 0,
    }

    public struct Level {
        public int level;
        public float pluss;
        public int exp;
        public int expToNextLv;
    }

    public enum PoolType {
        Bullet = 0,
        Zombie
    }

    public enum Enemigos {
        Zombie = 0,
        BigZombie
    }

    public enum Ammo {
        Bullets = 0,
        RaylCast
    }
    
    public struct Weapon {
        public int ammo;
        public int shootRate;
        public float shootSoeed;
        public float dispersion;
        public float reloadTime;

        public Weapon(int cap, int rate, float speed, float angle, float reca) {
            this.ammo = cap;
            this.shootRate = rate;
            this.shootSoeed = speed;
            this.dispersion = angle;
            this.reloadTime = reca;
        }
    }
    static public Weapon[] weapons = new Weapon[3] {   
        // Pistol
        new Weapon(6,       // Ammo
                   1,       // Rate
                   0.3f,    // Shoot Speed
                   3f,      // Dispercion Rate
                   1.3f),   // Reload Time
        // Shotgun
        new Weapon(3,       // Ammo
                   10,      // Rate
                   0.6f,    // Shoot Speed
                   20f,     // Dispercion Rate
                   2.4f),   // Reload Time
        // MachineGun
        new Weapon(45,      // Ammo
                   1,       // Rate
                   0.05f,   // Shoot Speed
                   5,       // Dispercion Rate
                   1.8f)    // Reload Time
    };
    public enum Weapons {
        Pistol = 0,
        Shotgun,
        MachineGun
    }

    static public float[] weaponReloadTime =
        {   1.3f };

    static public float playerSpeed = 1;

    static public float zombieSpeed = 0.6f;
    static public int zombiePoints = 5;
    static public int zombieExp = 25;

    static public float zombieBossSpeed = 0.4f;
    static public int zombieBossPoints = 100;
    static public int zombieBossExp = 500;

}
