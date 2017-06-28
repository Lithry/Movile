using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchscreen : IInput {
    private Vector3 lookAt;
    private Quaternion actualLookAt = new Quaternion(0, 0.707f, 0, 0.707f);
    private float angle;
    private Vector3 beginTouchPositionToMove;
    private Vector3 actualTouchPositionToMove;
    private Vector3 beginTouchPositionToLook;
    private Vector3 actualTouchPositionToLook;
    private float shootRequiresDistance;

    public Vector3 Movement() {
        foreach (Touch touch in Input.touches) {
            if (Camera.main.ScreenToViewportPoint(touch.position).x < 0.5) {
                if (touch.phase == TouchPhase.Began) {
                    beginTouchPositionToMove.x = touch.position.x;
                    beginTouchPositionToMove.y = 0;
                    beginTouchPositionToMove.z = touch.position.y;
                }
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
                    actualTouchPositionToMove.x = touch.position.x;
                    actualTouchPositionToMove.y = 0;
                    actualTouchPositionToMove.z = touch.position.y;

                    return (actualTouchPositionToMove - beginTouchPositionToMove).normalized;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
                    actualTouchPositionToMove.x = 0;
                    actualTouchPositionToMove.z = 0;

                    return actualTouchPositionToMove.normalized;
                }
            }
        }
        return actualTouchPositionToMove.normalized;
    }

    public Quaternion LookAt() {
        foreach (Touch touch in Input.touches) {
            if (Camera.main.ScreenToViewportPoint(touch.position).x > 0.5) {
                if (touch.phase == TouchPhase.Began) {
                    beginTouchPositionToLook = touch.position;
                }
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
                    actualTouchPositionToLook = touch.position;

                    lookAt = actualTouchPositionToLook - beginTouchPositionToLook;

                    shootRequiresDistance = lookAt.magnitude;

                    angle = -Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;

                    actualLookAt = Quaternion.AngleAxis(angle, Vector3.up);
                }
                return actualLookAt;
            }
        }
        return actualLookAt;
    }

    public bool Fire() {
        foreach (Touch touch in Input.touches) {
            if (Camera.main.ScreenToViewportPoint(touch.position).x > 0.5) {
                if (shootRequiresDistance > 1)
                    return true;
            }
        }
        return false;
    }
}
