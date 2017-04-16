using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour {
    static public ControlsManager instance = null;

    private bool up;
    private bool down;
    private bool right;
    private bool left;
    private bool fire;

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        up = Input.GetAxisRaw("Vertical") > 0 ? true : false;
        down = Input.GetAxisRaw("Vertical") < 0 ? true : false;
        right = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
        left = Input.GetAxisRaw("Horizontal") < 0 ? true : false;
        fire = Input.GetButtonDown("Fire1") ? true : false;
          
    }

    public bool UpBottom() {
        return up;
    }

    public bool DownBottom() {
        return down;
    }

    public bool RightBottom() {
        return right;
    }

    public bool LeftBottom() {
        return left;
    }

    public bool FireBottom() {
        return fire;
    }
}
