using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour{

    [SerializeField] StageManager StageManager;
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] Canvas StatisticsScreen;
    int enemyCount;

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
        StatisticsScreen.gameObject.SetActive(true);
        Time.timeScale = .25f;
    }

    public void SpawningComplete(){
        enemiesAreSpawned = true;
    }
}
