using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour {
    public static UIScript instance;
    [SerializeField] TextMeshProUGUI numberText;
    private int numberCount = 0;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        PlayerInteractionControllableUnit.instance.OnControllableUnitPickUp += PlayerController_OnControllableUnitPickUp;
        UpdateText();
    }

    private void UpdateText() {
        numberText.text = numberCount.ToString();
    }

    private void PlayerController_OnControllableUnitPickUp(object sender, EventArgs e) {
        numberCount++;
        UpdateText();
    }

    public void DeathOfCrab() {
        numberCount--;
        UpdateText();
    }

    public int GetCrabCount() {
        return numberCount;
    }
}
