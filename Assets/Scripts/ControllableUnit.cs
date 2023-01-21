using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableUnit : MonoBehaviour {
    [SerializeField] private bool isCurrentlyControlledByPlayer;
    private Transform followPoint;

    private void Awake() {
        isCurrentlyControlledByPlayer = false;
    }

    private void Update() {
        switch (isCurrentlyControlledByPlayer) {
            case true:
                FollowtheFollowPoint();
                break;
            case false:
                Wander();
                break;

        }
    }

    public void UpdateControlledByPlayer() {
        isCurrentlyControlledByPlayer = true;
        UpdateFollowPoint();
    }

    private void Wander() {

    }

    private void FollowtheFollowPoint() {
        Vector3 targetLocation = followPoint.position;
        Vector3 currentLocation = transform.position;
        Vector3 movement = (currentLocation - targetLocation).normalized;
        float movementSpeed = 10f;
        float buffOffset = 5f;
        if ((Math.Abs(currentLocation.x - targetLocation.x) > buffOffset) ||
                (Math.Abs(currentLocation.z - targetLocation.z) > buffOffset)) {
            transform.Translate(movement * movementSpeed * Time.deltaTime);
        }
        if (Math.Abs(currentLocation.y - targetLocation.y) > buffOffset) {
            // jump
            Debug.Log("Jump");
        }
    }

    private void UpdateFollowPoint() {
        this.followPoint = PlayerController.instance.GetTransform();
    }

    public bool GetIfCurrentlyControlledByPlayer() {
        return isCurrentlyControlledByPlayer;
    }

    private void Death() {
        Destroy(gameObject);
    }
}
