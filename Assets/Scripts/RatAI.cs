using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : MonoBehaviour {
    private enum State {
        Wander,
    }

    private State state;
    private bool wanderActionDone;
    [SerializeField] private GameObject wanderAreaBoundary;
    private float boundaryx_1, boundaryx_2, boundaryz_1, boundaryz_2;
    private float wanderBuffer = 1f;
    private Vector3 targetToWanderPos;

    private void Start() {
        Vector3 boundsMin = wanderAreaBoundary.GetComponent<BoxCollider>().bounds.min;
        Vector3 boundsMax = wanderAreaBoundary.GetComponent<BoxCollider>().bounds.max;
        boundaryx_1 = boundsMin.x;
        boundaryx_2 = boundsMax.x;
        boundaryz_1 = boundsMin.z;
        boundaryz_2 = boundsMax.z;
        wanderActionDone = true;
        state = State.Wander;
        Debug.Log(wanderAreaBoundary.name + " min: " + wanderAreaBoundary.GetComponent<BoxCollider>().bounds.min);
        Debug.Log(wanderAreaBoundary.name + " max: " + wanderAreaBoundary.GetComponent<BoxCollider>().bounds.max);
        Debug.Log(wanderAreaBoundary.name + " x: " + boundaryx_1 + ", " + boundaryx_2);
        Debug.Log(wanderAreaBoundary.name + " z: " +boundaryz_1 + ", " + boundaryz_2);
    }

    private void Update() {
        switch (state) {
            default:
            case State.Wander:
                if (wanderActionDone) {
                    wanderActionDone = false;
                    Wander();
                }
                break;
        }
        if ((Mathf.Abs(transform.position.x-targetToWanderPos.x) < wanderBuffer) && (Mathf.Abs(transform.position.z - targetToWanderPos.z) < wanderBuffer)) {
            wanderActionDone = true;
        }
        FollowtheFollowPoint();
    }

    private void Wander() {
        float x = Random.Range(boundaryx_1, boundaryx_2);
        float z = Random.Range(boundaryz_1, boundaryz_2);
        targetToWanderPos = new Vector3(x, transform.position.y, z);
        Debug.Log(name + " in " + wanderAreaBoundary.name + " traveling to " + targetToWanderPos);
    }

    private void FollowtheFollowPoint() {
        Vector3 lookAtPosition = targetToWanderPos;
        lookAtPosition.y = transform.position.y;
        transform.LookAt(lookAtPosition);
        Vector3 currentLocation = transform.position;

        Vector3 movement = (currentLocation - targetToWanderPos).normalized;
        movement.x = Mathf.Abs(movement.x);
        movement.y = Mathf.Abs(movement.y);
        movement.z = Mathf.Abs(movement.z);
        float movementSpeed = 5f;
        transform.Translate(movement * movementSpeed * Time.deltaTime);
    }
}
