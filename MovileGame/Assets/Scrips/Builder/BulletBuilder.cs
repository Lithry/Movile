using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuilder : MonoBehaviour {
    static public BulletBuilder instance = null;
    private GameObject obj;
    
    
    void Awake () {
        instance = this;
	}
	
    public GameObject Build(string type, Vector3 pPos, Vector3 pRot)
    {
        switch (type)
        {
            case "Pistol":
                obj = BulletFactory.instance.Create(type);
                obj.AddComponent<Pistol>();
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                return obj;
            default:
                return null;
        }
    }
}
