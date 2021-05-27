using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    [SerializeField] Canvas MainMenu;
    [SerializeField] Canvas PauseMenu;
    [SerializeField] Canvas PowersMenu;
    [SerializeField] Canvas LoadingScreenCanvas;
    [SerializeField] Image LoadingPanel;

    string currentStageKey = "CurrentStage";

    void Awake() {
        if (PlayerPrefs.GetInt(currentStageKey) > 0) {
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

    public void ContinueGameButton() {
        PauseMenu.gameObject.SetActive(false);
        PowersMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void PowersMenuButton(){
        PowersMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGameButton() { // not implemented
        Application.Quit();
    }

}
