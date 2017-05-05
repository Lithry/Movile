using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    static public InputManager instance = null;
    private IInput input;

    void Awake() {
        instance = this;

#if   UNITY_EDITOR
        input = new InputKeyboard();
#elif UNITY_STANDALONE_WIN
        input = new InputKeyboard();
#elif UNITY_ANDROID
        input = new InputTouchscreen();
#endif
    }

    public bool Fire() {
        return (PlayerManager.instance.PlayerAlive()) ? input.Fire() : false; 
    }

    public Vector3 Movement() {
        return (PlayerManager.instance.PlayerAlive()) ? input.Movement() : Vector3.zero;
    }

    public Quaternion LookAt() {
        return (PlayerManager.instance.PlayerAlive()) ? input.LookAt() : new Quaternion(0, 0.707f, 0, 0.707f);
    }
}