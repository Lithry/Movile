using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Units {
    public enum Player {
        Player = 0,
    }

    public enum Enemigos {
        Zombie = 0,
    }
    public struct Weapons
    {
        Armas Type;
        float ReloadTime;
    }
    
    public enum Armas {
        Pistola = 0,
        UZI
    }

    static public float[] weaponReloadTime =
        {   1.3f,
            0.3f };
    /*static public Weapons[] weapons =
    {
        Armas.Pistola, 2.0f;
    };*/


    static public float playerSpeed = 1;

    static public float zombieSpeed = 0.7f;
    static public int zombiePoints = 5;
	
}
