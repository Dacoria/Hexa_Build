using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResetCameraPositionScript : BaseEventCallback
{
    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;

    void Start()
    {
        originalCameraPosition = Camera.main.transform.position;
        originalCameraRotation = Camera.main.transform.rotation;
    }   

    public void ResetCamera()
    {
        var targetPos = originalCameraPosition;
        var targetRot = originalCameraRotation;

        // geleidelijk bewegen + draaien naar target plek+rot
        var lerpMovement = gameObject.GetAdd<LerpMovement>();
        lerpMovement.MoveToDestination(endPosition: targetPos, duration: 0.6f, destroyGoOnFinished: false);

        var lerpRotation = gameObject.GetAdd<LerpRotation>();
        lerpRotation.RotateTowardsAngle(endRotation: targetRot, duration: 0.6f, destroyGoOnFinished: false);
    }
}