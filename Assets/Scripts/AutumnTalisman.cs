using System.Collections.Generic;
using UnityEngine;

public class AutumnTalisman : MonoBehaviour {

    [SerializeField] Grid[] Grids;
    [SerializeField] List<EnemyController> Enemies;

    //on a timer
    //grab a list of all the enemies within one grid block.
    //aoe damage to enemies

    void Start() {
        InvokeRepeating("Attack", 0f, 3f);
    }

    //TODO make sure we only got one of each enemy
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
        foreach(EnemyController enemy in Enemies){
            enemy.GetComponent<EnemyController>().takeDamage(1);
        }
    }
    //on a timer damage enemies
}
