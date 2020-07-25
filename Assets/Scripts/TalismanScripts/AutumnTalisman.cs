using System.Collections.Generic;
using UnityEngine;

public class AutumnTalisman : MonoBehaviour {

    [SerializeField] Grid[] Grids;
    [SerializeField] List<EnemyPathing> Enemies;

    [Header("String Commands")]
    string attack = "Attack";

    void Start() {
        InvokeRepeating(attack, 0f, 3f);
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

    void Attack(){
        foreach(EnemyPathing enemy in Enemies){
            enemy.GetComponentInChildren<EnemyController>().takeDamage(1);
        }
    }
}
