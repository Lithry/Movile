using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuilder : MonoBehaviour {
    static public BulletBuilder instance = null;
    private GameObject obj;
    
    
    void Awake () {
        instance = this;
	}
	
    public GameObject Build(string type)
    {
        switch (type)
        {
            case "Pistol":
                obj = BulletFactory.instance.Create(type);
                obj.AddComponent<Pistol>();
                return obj;
            default:
                return null;
        }
    }
}
