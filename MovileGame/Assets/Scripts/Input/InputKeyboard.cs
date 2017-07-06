using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboard : IInput {
    private Vector3 lookAt;
    private Vector3 direction;
    private float angle;

    public Vector3 Movement() {
        direction.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (direction.magnitude > 1)
            return Vector3.Normalize(direction);
        else
            return direction;
    }

    public Quaternion LookAt() {
        lookAt = Input.mousePosition - Camera.main.WorldToScreenPoint(PlayerManager.instance.PlayerPos());
        angle = -Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.up);
    }

    public bool Fire() {
        return Input.GetButton("Fire1") ? true : false;
    }

    public void Clean() {
        lookAt.Set(0, 0, 0);
        direction.Set(0, 0, 0);
        angle = 0;
    }
}
