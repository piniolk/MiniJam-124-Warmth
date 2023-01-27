using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionControllableUnit : MonoBehaviour {

    public event EventHandler OnControllableUnitPickUp;
    public static PlayerInteractionControllableUnit instance;

    private void Awake() {
        instance = this;
    }

    private void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("ControllableUnit")) {
            if (!other.gameObject.GetComponent<ControllableUnit>().GetIfCurrentlyControlledByPlayer()) {
                other.GetComponent<ControllableUnit>().UpdateControlledByPlayer();
                OnControllableUnitPickUp?.Invoke(this, EventArgs.Empty);
            }
        }
        if (other.gameObject.GetComponent<Goal>()) {
            GameManager.Instance.GoalAchieved();
        }
    }
}
