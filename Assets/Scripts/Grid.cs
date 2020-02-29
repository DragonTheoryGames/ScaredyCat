using UnityEngine;

public class Grid : MonoBehaviour {
    
    [SerializeField] GridManager parentGrid;
    [SerializeField] bool hasTalisman = false;
    GameObject talisman;

    public void SetTalisman(GameObject tal) {
        if (!hasTalisman){
            hasTalisman = true;
            talisman = tal;
            if(talisman.GetComponent<AttackTalisman>() != null){ //gives room to attack talismans
                talisman.GetComponent<AttackTalisman>().SetGridManager(parentGrid);
            }
        }
        else if (hasTalisman) {
            Object.Destroy(talisman);
            talisman = tal;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.GetComponent<EnemyController>() != null) { //check for enemy
            GridManager previousGrid = col.gameObject.GetComponent<EnemyController>().GetGrid();
            if(previousGrid != null) {
                previousGrid.RemoveEnemy(col.gameObject.GetComponent<EnemyController>()); //remove enemy from prior grid
            }
            col.gameObject.GetComponent<EnemyController>().SetGrid(parentGrid); //set enemies new grid
            parentGrid.AddEnemy(col.gameObject.GetComponent<EnemyController>()); //add to enemies list.
        }
    }
}