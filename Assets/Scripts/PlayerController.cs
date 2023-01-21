using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public event EventHandler OnControllableUnitPickUp;
    public static PlayerController instance;
    private float movementSpeed = 10f;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z);

        transform.Translate(movement * movementSpeed * Time.deltaTime);
        Vector3 y = new Vector3(0, 10, 0);
        if (Input.GetKeyDown(KeyCode.Space)) {
            transform.Translate(y * movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("ControllableUnit")) {
            if (!other.gameObject.GetComponent<ControllableUnit>().GetIfCurrentlyControlledByPlayer()) {
                other.GetComponent<ControllableUnit>().UpdateControlledByPlayer();
                OnControllableUnitPickUp?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public Transform GetTransform() {
        return transform;
    }
}
