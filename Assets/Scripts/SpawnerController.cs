using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerController : MonoBehaviour {
    
    [Header("Spawners")]
    Vector2 livingRoomSpawn = new Vector2(-75, -8);
    Vector2 kitchenSpawn = new Vector2(75, -8);
    [SerializeField] Transform livingRoomCenter;

    Vector2 atticLeft = new Vector2(-75, 51.5f);
    Vector2 atticRight = new Vector2(75, 51.5f);
    [SerializeField] Transform atticCenter;

    [SerializeField] int totalEnemies;
    [SerializeField] int spawnedEnemies;

    [SerializeField] GameObject kurobouzu;

    [SerializeField] Text victory;

    Vector2[] rooms = new Vector2[4];

    void Start() {
        rooms = new Vector2[] {livingRoomSpawn, kitchenSpawn, atticLeft, atticRight};
        StartCoroutine(SpawnEnemies());
    }

    private void FixedUpdate() {
        if(spawnedEnemies >= totalEnemies) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length <= 0) {
                victory.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    IEnumerator SpawnEnemies() {
        Transform nextobjective;
        for(spawnedEnemies = 0; spawnedEnemies < totalEnemies; spawnedEnemies++) {
            int seconds = Random.Range(0, 4);
            int spawn = Random.Range(0, 4);
            yield return new WaitForSeconds(seconds);
            GameObject Enemy = Instantiate(kurobouzu, rooms[spawn], Quaternion.identity);
            nextobjective = (spawn == 0 || spawn == 1) ? livingRoomCenter : atticCenter;
            Enemy.GetComponent<EnemyPathing>().Setnextobjective(nextobjective);
        }
    }
}
