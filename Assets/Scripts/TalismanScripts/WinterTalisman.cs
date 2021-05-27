using System.Collections.Generic;
using UnityEngine;

public class WinterTalisman : MonoBehaviour {
    
    [SerializeField] Grid Grid;
    [SerializeField] List<EnemyPathing> Enemies;

    [SerializeField] float speednormalized = .04f;
    [SerializeField] float speedreduction = .03f;

    void FixedUpdate() {
        SlowEnemies();
    }

    public void SetGrid(Grid newgrid){
        Grid = newgrid;
    }

    private void SlowEnemies() {
        if (Enemies.Count == 0){return;}
        foreach (EnemyPathing enemy in Enemies) {
            try{
                enemy.GetComponent<EnemyPathing>().SetSpeed(speednormalized);
            }
            catch{}
        }
        Enemies.Clear();
        Enemies.AddRange(Grid.GetEnemies());
        foreach (EnemyPathing enemy in Enemies) {
            try{
                enemy.GetComponent<EnemyPathing>().SetSpeed(speedreduction - (PowersManager.winterPower/1000));
            }
            catch{}
        }
    }


}
