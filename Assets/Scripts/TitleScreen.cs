using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject creditsScreen;
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void CreditsScreen() {
        titleScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void TitleScreenOn() {
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }
}
