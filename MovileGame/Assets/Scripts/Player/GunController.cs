using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    private Transform tip;

	void Start () {
        tip = transform.FindChild("Tip");
	}
	
    public void FireGun(Units.Armas type) {
        BulletBuilder.instance.Build(type, tip.position, tip.eulerAngles);
    }
}