using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI numberText;
    private int numberCount = 0;


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
}
