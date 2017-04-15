using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    private Transform tip;
	// Use this for initialization
	void Start () {
        tip = transform.FindChild("Tip");
	}
	
    public void FireGun(string type)
    {
        BulletBuilder.instance.Build(type, tip.position, tip.eulerAngles);
    }
}
