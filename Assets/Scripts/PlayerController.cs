using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController instance { get; private set; }
    private float movementSpeed = 10f;
    private bool hasJumped;

    private void Awake() {
        if (instance != null) {
            Debug.LogError("There's more than one PlayerController! " + transform + " - " + instance);
            Destroy(gameObject);
            return;
        }
        instance = this;
        hasJumped = false;
    }

    private void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z);

        transform.Translate(movement * movementSpeed * Time.deltaTime);
        Vector3 y = new Vector3(0, 12, 0);
        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped) {
            //transform.Translate(y * movementSpeed * Time.deltaTime);
            gameObject.GetComponent<Rigidbody>().velocity += y;
            hasJumped = true;
        }
        if(gameObject.GetComponent<Rigidbody>().velocity.y == 0) {
            hasJumped = false;
        }
    }



    public Vector3 GetPosition() {
        return transform.position;
    }

    public Transform GetTransform() {
        return transform;
    }

}
