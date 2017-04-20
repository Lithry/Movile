using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    static public InputManager instance = null;
    private IInput input;

    private bool fire;

    void Awake()
    {
        instance = this;

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        input = new InputKeyboard();
#elif UNITY_ANDROID
        input = new InputAndroid();
#endif

    }

    void Update()
    {
        fire = Input.GetButtonDown("Fire1") ? true : false;
    }

    public bool Fire()
    {
        return input.Fire();
    }

    public Vector3 Movement()
    {
        return input.Movement();
    }

    public Quaternion LookAt()
    {
        return input.LookAt();
    }
}