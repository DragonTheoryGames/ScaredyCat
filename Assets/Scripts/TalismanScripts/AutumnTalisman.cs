using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AutumnTalisman : MonoBehaviour {

    [SerializeField] Grid[] Grids;
    [SerializeField] List<EnemyPathing> Enemies;

    [Header("String Commands")]
    string attack = "Attack";

    void Start() {
        StartCoroutine(Attack());
    }

    void FixedUpdate() {
        Enemies.Clear();
        foreach (Grid grid in Grids){
            Enemies.AddRange(grid.GetEnemies());
        }
    }

    public void SetGrid(Grid parentGrid){
        Grids = parentGrid.GetNeighbor();
    }

    IEnumerator Attack(){
        foreach(EnemyPathing enemy in Enemies){
            enemy.GetComponentInChildren<EnemyController>().takeDamage(1);
        }
        yield return new WaitForSeconds(3f - (PowersManager.autumnSpeed/10));
        StartCoroutine(Attack());
    }
}
