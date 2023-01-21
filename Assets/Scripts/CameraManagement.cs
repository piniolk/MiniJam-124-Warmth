using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour {
    private Transform followPoint;

    private void Start() {
        followPoint = PlayerController.instance.GetTransform();
    }

    private void Update() {
        TrackPosition();
        //Rotation();
    }

    private void TrackPosition() {
        Vector3 newPosition = followPoint.position;
        float yOffset = 10f;
        float zOffset = -15f;
        newPosition.y = yOffset;
        newPosition.z += zOffset;
        transform.position = newPosition;
    }

    private void Rotation() {
        Vector3 rotationVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Q)) {
            rotationVector.y = +1f;
        }
        if (Input.GetKey(KeyCode.E)) {
            rotationVector.y = -1f;
        }

        float rotationSpeed = 100f;

        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }
}
