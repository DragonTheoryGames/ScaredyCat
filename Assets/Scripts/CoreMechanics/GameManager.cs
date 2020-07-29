using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour{

    [SerializeField] StageManager StageManager;
    [SerializeField] TextMeshProUGUI gameOver;
    List<GameObject> enemies;

    bool enemiesAreSpawned = false;
    string victory = "Victory";

    void FixedUpdate() {
        if(enemiesAreSpawned) {
            CheckForVictory();
        }
    }

    private void CheckForVictory() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");//<-- Somebody wrote bad code
        if (enemies.Length <= 0) {
            GameOver(victory);
        }
    }

    public void GameOver(string gameOverText) {
        gameOver.text = gameOverText;
        if (gameOverText == victory){
            
        }
        Time.timeScale = .25f;
    }

    public void SpawningComplete(){
        enemiesAreSpawned = true;
    }

    void LoadNextStage() {
        StageManager.IncrementStage();
        //SceneManager.LoadNextStage();
    }
}
