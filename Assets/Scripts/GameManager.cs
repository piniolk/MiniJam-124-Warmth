using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    [SerializeField] private GameObject goalScreen;
    [SerializeField] private GameObject UIScreen;
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private TextMeshProUGUI forwardSlashText;
    [SerializeField] private TextMeshProUGUI totalNumberText;
    [SerializeField] private TextMeshProUGUI goalText;
    private int totalCrabs = 0;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more than one GameManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start() {
        foreach (GameObject crab in GameObject.FindGameObjectsWithTag("ControllableUnit")) {
            totalCrabs++;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseScreenToggle();
        }
    }

    public void PauseScreenToggle() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        } else {
            Time.timeScale = 0;
        }
        PauseScreen.SetActive(!PauseScreen.activeSelf);
    }

    public void GoalAchieved() {
        Debug.Log("You win!");
        Time.timeScale = 0;
        UIScreen.SetActive(false);
        goalScreen.SetActive(true);
        UpdateText();
    }

    public void GoToTitleScreen() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void UpdateText() {
        int crabs = UIScript.instance.GetCrabCount();
        numberText.text = crabs.ToString();
        totalNumberText.text = totalCrabs.ToString();
        if (crabs == totalCrabs) {
            goalText.text = "It's party!\nAll crabs are free!";
        } else if (crabs == 0) {
            numberText.text = "";
            forwardSlashText.text = "";
            totalNumberText.text = "";
            goalText.text = "No Crabs Escaped!";
        }
    }
}
