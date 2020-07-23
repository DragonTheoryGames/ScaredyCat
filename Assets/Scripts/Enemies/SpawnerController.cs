using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnerController : MonoBehaviour {

    [SerializeField] GameManager GameManager;

    [Header("Stage")]
    [SerializeField] _SriptableLevel Stage;
    [SerializeField] StageManager StageManager;
    int enemyCount;
    int enemySpawnTime;
    int enemySpawners;
    int nextStage;
    [SerializeField] bool isMenu = false;

    [Header("Spawners")]
    Vector2 livingRoomSpawn = new Vector2(-75, -6f);
    Vector2 kitchenSpawn = new Vector2(75, -6);
    [SerializeField] Transform livingRoomCenter;

    Vector2 atticLeft = new Vector2(-75, 56f);
    Vector2 atticRight = new Vector2(75, 56f);
    [SerializeField] Transform atticCenter;

    int SpawnRooms;
    [SerializeField] int spawnedEnemies;
    [SerializeField] GameObject kurobouzu;

    [SerializeField] Text victory;

    Vector2[] rooms = new Vector2[4];

    int nameCounter = 0;

    void Start() {
        SetLevelVariables();
    }

    public void SetLevelVariables() {
        Stage = StageManager.GetStage();
        enemyCount = Stage.enemyCount;
        enemySpawnTime = Stage.enemySpawnTime;
        enemySpawners = Stage.enemySpawners;
        nextStage = Stage.nextStage;
        SpawnRooms = (nextStage <= 6) ? 2 : 4; 
        Time.timeScale = 1f;
        rooms = new Vector2[] { livingRoomSpawn, kitchenSpawn, atticLeft, atticRight };
        StartCoroutine(SpawnEnemies());
    }

    private void FixedUpdate() {
        CountEnemies();
    }

    private void CountEnemies() {
        if (spawnedEnemies >= enemyCount) {
            GameManager.SpawningComplete();
        }
    }

    IEnumerator SpawnEnemies() {
        Transform nextobjective;
        for(spawnedEnemies = 0; spawnedEnemies < enemyCount; spawnedEnemies++) {
            int seconds = Random.Range(0, enemySpawnTime);
            int spawn = Random.Range(0, SpawnRooms);
            yield return new WaitForSeconds(seconds);
            GameObject Enemy = Instantiate(kurobouzu, rooms[spawn], Quaternion.identity);
            nextobjective = (spawn == 0 || spawn == 1) ? livingRoomCenter : atticCenter;
            Enemy.GetComponent<EnemyPathing>().Setnextobjective(nextobjective);
            Enemy.name = "Enemy " + nameCounter.ToString();
            nameCounter++;
        }
    }
}
