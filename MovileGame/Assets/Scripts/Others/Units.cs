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
    
    public enum Weapons {
        Gun = 0,
    }

    static public float[] weaponReloadTime =
        {   1.3f };
    /*static public Weapons[] weapons =
    {
        Armas.Pistola, 2.0f;
    };*/


    static public float playerSpeed = 1;

    static public float zombieSpeed = 0.7f;
    static public int zombiePoints = 5;
    static public int zombieExp = 25;
	
}
