using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour {
    
    [SerializeField] Grid[] Neighbors;
    [SerializeField] List<EnemyController> myEnemies;
    [SerializeField] bool hasTalisman = false;
    GameObject talisman;

    public Grid[] GetNeighbor(){
        return Neighbors;
    }

    public void SetTalisman(GameObject tal) {
        if (!hasTalisman){
            hasTalisman = true;
            talisman = tal;
        }
        else if (hasTalisman) {
            Object.Destroy(talisman);
            talisman = tal;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.GetComponent<EnemyController>()) { //check for enemy
            myEnemies.Add(col.gameObject.GetComponent<EnemyController>());
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<EnemyController>())
        { //check for enemy
            myEnemies.Remove(col.gameObject.GetComponent<EnemyController>());
        }
    }

    public List<EnemyController> GetEnemies(){
        return myEnemies;
    }
}