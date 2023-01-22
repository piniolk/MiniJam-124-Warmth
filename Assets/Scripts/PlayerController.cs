using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
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
            //transform.Translate(y * movementSpeed * Time.deltaTime);
            gameObject.GetComponent<Rigidbody>().velocity += y;
        }
    }



    public Vector3 GetPosition() {
        return transform.position;
    }

    public Transform GetTransform() {
        return transform;
    }

}
