using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    //TODO: Make Controller Friendly

    [SerializeField] Animator transitionAnim;
    string currentStageKey = "CurrentStage";

    void Update() {
        StartGame();
    }

    public void NextScene() {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            StartCoroutine(SceneLoader(nextScene));
    }

    public void NextStage() {
        PlayerPrefs.SetInt("CurrentStage", PlayerPrefs.GetInt("CurrentStage") + 1);
        StartCoroutine(SceneLoader(SceneManager.GetActiveScene().buildIndex));
    }

    void StartGame() { //I hate this
        if (Input.GetKeyDown(KeyCode.Space)){
            if (SceneManager.GetActiveScene().buildIndex == 2){
                PlayerPrefs.SetInt(currentStageKey, 0);
                StartCoroutine(SceneLoader(SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
    }

    public void NewGame() {
        PlayerPrefs.SetInt(currentStageKey, 1);
        StartCoroutine(SceneLoader(SceneManager.GetActiveScene().buildIndex));
    }

    //public void LoadGame(){}

    public void ReturnToMainMenuButton() {
        Time.timeScale = 1;
        PlayerPrefs.SetInt(currentStageKey, 0);
        StartCoroutine(SceneLoader(3));
    }

    IEnumerator SceneLoader(int sceneIndex) {
        transitionAnim.SetTrigger("EndScene");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }

    public void StartStage(){
        PlayerPrefs.SetInt("CurrentStage", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
