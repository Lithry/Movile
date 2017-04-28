using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboard : IInput {
    private Vector3 lookAt;
    private float angle;
    private Vector3 direction;

    public Vector3 Movement()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = 0;
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction.magnitude > 1)
            return Vector3.Normalize(direction);
        else
            return direction;
    }

    public Quaternion LookAt()
    {
        lookAt = Input.mousePosition - Camera.main.WorldToScreenPoint(PlayerManager.instance.PlayerPos());
        angle = -Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.up);
    }

    public bool Fire()
    {
        return Input.GetButtonDown("Fire1") ? true : false;
    }
}
