using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public Material white;
    public Material orange;
    public Material green;

    public GameObject prefab;
    // Use this for initialization
    void Start () {
        Vector3 aP = new Vector3(1, 0, -2.5f);
        GameObject a = Instantiate(prefab);
        a.transform.position = aP;
        a.GetComponent<MeshRenderer>().material = white;
        a.GetComponent<Item>().SetItemType(Units.Weapons.Pistol);

        Vector3 bP = new Vector3(-1, 0, -2.5f);
        GameObject b = Instantiate(prefab);
        b.transform.position = bP;
        b.GetComponent<MeshRenderer>().material = orange;
        b.GetComponent<Item>().SetItemType(Units.Weapons.Shotgun);

        Vector3 cP = new Vector3(0, 0, -2.5f);
        GameObject c = Instantiate(prefab);
        c.transform.position = cP;
        c.GetComponent<MeshRenderer>().material = green;
        c.GetComponent<Item>().SetItemType(Units.Weapons.MachineGun);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
