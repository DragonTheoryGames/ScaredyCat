using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour {
    
    [SerializeField] Grid[] Neighbors;
    [SerializeField] List<EnemyPathing> myEnemies;
    [SerializeField] Talisman player;
    [SerializeField] bool hasTalisman = false;
    [SerializeField]GameObject talisman;

    public List<EnemyPathing> GetEnemies() {
        return myEnemies;
    }
    public Grid[] GetNeighbor() {
        return Neighbors;
    }

    public void SetTalisman(GameObject tal) {
        if (hasTalisman) {
            Object.Destroy(talisman);
            talisman = tal;
        }
        else if (!hasTalisman) {
            hasTalisman = true;
            talisman = tal;
        } 
    }

    private void OnTriggerEnter2D(Collider2D col) {
        AddEnemy(col);
    }

    private void OnTriggerExit2D(Collider2D col) {
        RemoveEnemy(col);
    }

    private void AddEnemy(Collider2D col) {
        if (col.gameObject.GetComponent<EnemyPathing>()) {
            myEnemies.Add(col.gameObject.GetComponent<EnemyPathing>());
        }
    }    

    private void RemoveEnemy(Collider2D col) {
        if (col.gameObject.GetComponent<EnemyPathing>()) {
            myEnemies.Remove(col.gameObject.GetComponent<EnemyPathing>());
        }
    }
}