using System.Collections.Generic;
using UnityEngine;

public class AutumnTalisman : MonoBehaviour {

    [SerializeField] Grid[] Grids;
    [SerializeField] List<EnemyPathing> Enemies;

    void Start() {
        InvokeRepeating("Attack", 0f, 3f);
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
