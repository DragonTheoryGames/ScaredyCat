using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    
    [SerializeField]List<EnemyController> enemies; 
  
    //add enemy to list
    public void AddEnemy(EnemyController enemy) {
        enemies.Add(enemy);
    }
    
    //remove enemy from list
    public void RemoveEnemy(EnemyController enemy) {
        enemies.Remove(enemy);
    }

    public List<EnemyController> GetEnemies(){
        return enemies;
    }
}
