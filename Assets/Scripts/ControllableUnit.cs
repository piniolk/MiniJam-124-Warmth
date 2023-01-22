using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableUnit : MonoBehaviour {
    [SerializeField] private bool isCurrentlyControlledByPlayer;
    private Transform followPoint;
    private Rigidbody rigidbody;

    private void Awake() {
        isCurrentlyControlledByPlayer = false;
        rigidbody = gameObject.GetComponent<Rigidbody>();
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
        transform.LookAt(followPoint.position);
        Vector3 targetLocation = followPoint.position;
        Vector3 currentLocation = transform.position;
        Vector3 movement = (currentLocation - targetLocation).normalized;
        movement.x = Math.Abs(movement.x);
        movement.y = Math.Abs(movement.y);
        movement.z = Math.Abs(movement.z);
        float movementSpeed = 4f;
        float buffOffset = 2.5f;
        //if ((Math.Abs(currentLocation.x - targetLocation.x) > buffOffset) || (Math.Abs(currentLocation.z - targetLocation.z) > buffOffset)) {
        if ((buffOffset < currentLocation.x - targetLocation.x ^ currentLocation.x - targetLocation.x < -buffOffset) || 
            (buffOffset < currentLocation.z - targetLocation.z ^ currentLocation.z - targetLocation.z < -buffOffset)) {
            transform.Translate(movement * movementSpeed * Time.deltaTime);
        } 
        if (Math.Abs(currentLocation.y - targetLocation.y) < 1f) {
            //rigidbody.velocity = Vector3.zero;
        }
        float yBuffOffset = 3f;
        if (targetLocation.y - currentLocation.y > yBuffOffset) {
            Vector3 y = new Vector3(0, 12, 0);
            rigidbody.velocity = y;
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
