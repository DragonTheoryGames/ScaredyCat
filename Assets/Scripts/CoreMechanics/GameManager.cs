using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    [SerializeField] StageManager StageManager;

    [SerializeField] Text gameOver;
    [SerializeField] Text victory;
    
    List<GameObject> enemies;
    bool enemiesAreSpawned = false;

    void FixedUpdate() {
        if(enemiesAreSpawned) {
            Victory();
        }
    }

    public void GameOver() {
        gameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void SpawningComplete(){
        enemiesAreSpawned = true;
    }

    private void Victory() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");//<-- Somebody wrote bad code
        if (enemies.Length <= 0) {
            victory.gameObject.SetActive(true);
            Time.timeScale = .25f;
            LoadNextStage();
        }
    }

    private void LoadNextStage() {
        //yield return new WaitForSeconds(2);
        StageManager.IncrementStage();
        SceneManager.LoadScene(1);
    }
}
