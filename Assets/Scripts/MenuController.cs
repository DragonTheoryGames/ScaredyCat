using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuController : MonoBehaviour {

    [SerializeField] Button button;
    [SerializeField] Canvas pauseMenu;

    private void Update() {
        MainMenuInput();
        CallPauseMenu();
    }

    private void CallPauseMenu() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (pauseMenu.gameObject.activeSelf) {
                pauseMenu.gameObject.SetActive(false);
            }
            else if (!pauseMenu.gameObject.activeSelf) {
                pauseMenu.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Button") {
            button = col.gameObject.GetComponent<Button>();
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject == button.gameObject) {
            button = null;
        }
    }

    private void MainMenuInput() {
        if (Input.GetKey(KeyCode.F)) {
            switch (button.name) {
                case "NewGameButton":
                    SceneManager.LoadScene(1);
                    break;
            }
        }
    }

    public void ContinueButton() {
        pauseMenu.gameObject.SetActive(false);
    }

    public void GoToMainMenuButton() {
        SceneManager.LoadScene(0);
    }

}
