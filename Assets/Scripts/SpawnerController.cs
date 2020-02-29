using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
    
    [Header("Spawners")]
    Vector2 livingRoomSpawn = new Vector2(-75, -8);
    Vector2 kitchenSpawn = new Vector2(75, -8);
    [SerializeField] Transform livingRoomCenter;

    Vector2 atticLeft = new Vector2(-75, 51.5f);
    Vector2 atticRight = new Vector2(75, 51.5f);
    [SerializeField] Transform atticCenter;
    
    [SerializeField] GameObject kurobouzu;

    Vector2[] rooms = new Vector2[4];

    void Start() {
        rooms = new Vector2[] {livingRoomSpawn, kitchenSpawn, atticLeft, atticRight};
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        int i;
        Transform nextobjective;
        for(i = 0; i < 50; i++) {
            int seconds = Random.Range(0, 10);
            int spawn = Random.Range(0, 4);
            yield return new WaitForSeconds(seconds);
            GameObject Enemy = Instantiate(kurobouzu, rooms[spawn], Quaternion.identity);
            nextobjective = (spawn == 0 || spawn == 1) ? livingRoomCenter : atticCenter;
            Enemy.GetComponent<EnemyPathing>().Setnextobjective(nextobjective);
        }
    }
}
