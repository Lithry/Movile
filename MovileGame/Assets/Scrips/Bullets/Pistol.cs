using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {

    private void Start()
    {
        Invoke("End", 2);
    }
    void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void End()
    {
        BulletFactory.instance.Destroy(gameObject);
    }
}
