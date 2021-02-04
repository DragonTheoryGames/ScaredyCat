using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuController : MonoBehaviour {

    [SerializeField] Canvas PauseMenu;
    [SerializeField] Canvas MainMenu;
    [SerializeField] Canvas PowersMenu;
    [SerializeField] StageManager StageManager;
    string currentStageKey = "CurrentStage";

    void Awake() {
        if (PlayerPrefs.GetInt(currentStageKey) > 0){
            MainMenu.gameObject.SetActive(false);
        }        
    }

    private void Update() {
        CallPauseMenu();
    }

    private void CallPauseMenu() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (PauseMenu.gameObject.activeSelf) {
                ContinueGameButton();
            }
            else if (!PauseMenu.gameObject.activeSelf) {
                PauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void StartHighestStage() {
        SceneManager.LoadScene(2);
    }

    public void NewGameButton(){
        PlayerPrefs.SetInt(currentStageKey, 1);
        SceneManager.LoadScene(2);
    }

    public void ContinueGameButton() {
        PauseMenu.gameObject.SetActive(false);
        PowersMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenuButton() {
        PlayerPrefs.SetInt(currentStageKey, 0);
        SceneManager.LoadScene(2);
    }

    public void PowersMenuButton(){
        PowersMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGameButton() { // not implemented
        Application.Quit();
    }

}
