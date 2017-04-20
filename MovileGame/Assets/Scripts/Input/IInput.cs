using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInput {
    Vector3 Movement();
    Quaternion LookAt();
    bool Fire();
}
