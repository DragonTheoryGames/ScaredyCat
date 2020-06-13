using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnerController : MonoBehaviour {

    [SerializeField] _SriptableLevel Stage;
    [SerializeField] StageManager StageManager;
    int enemyCount;
    int enemySpawnTime;
    [SerializeField]
    bool isMenu = false;

    [Header("Spawners")]
    Vector2 livingRoomSpawn = new Vector2(-75, -6.5f);
    Vector2 kitchenSpawn = new Vector2(75, -6.5f);
    [SerializeField] Transform livingRoomCenter;

    Vector2 atticLeft = new Vector2(-75, 56f);
    Vector2 atticRight = new Vector2(75, 56f);
    [SerializeField] Transform atticCenter;

    [SerializeField] int spawnedEnemies;
    [SerializeField] GameObject kurobouzu;

    [SerializeField] Text victory;

    Vector2[] rooms = new Vector2[4];

    int nameCounter = 0;

    void Start() {
        Stage = StageManager.GetStage();
        SetLevelVariables();
        Time.timeScale = 1f;
        rooms = new Vector2[] {livingRoomSpawn, kitchenSpawn, atticLeft, atticRight};
        StartCoroutine(SpawnEnemies());
    }

    void SetLevelVariables() {
        enemyCount = Stage.enemyCount;
        enemySpawnTime = Stage.enemySpawnTime;
    }

    private void FixedUpdate() {
        if (isMenu) { return; }
        if(spawnedEnemies >= enemyCount) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length <= 0) {
                victory.gameObject.SetActive(true);
                Time.timeScale = .25f;
                LoadNextStage();
            }
        }
    }

    private void LoadNextStage() {
        //yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    IEnumerator SpawnEnemies() {
        Transform nextobjective;
        for(spawnedEnemies = 0; spawnedEnemies < enemyCount; spawnedEnemies++) {
            int seconds = Random.Range(0, enemySpawnTime);
            int spawn = Random.Range(0, 4);
            yield return new WaitForSeconds(seconds);
            GameObject Enemy = Instantiate(kurobouzu, rooms[spawn], Quaternion.identity);
            nextobjective = (spawn == 0 || spawn == 1) ? livingRoomCenter : atticCenter;
            Enemy.GetComponent<EnemyPathing>().Setnextobjective(nextobjective);
            Enemy.name = "Enemy " + nameCounter.ToString();
            nameCounter++;
        }
    }
}
