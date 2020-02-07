using UnityEngine;

public class Talisman : MonoBehaviour {
    
    [SerializeField] GameObject AttackTalisman;
    [SerializeField] GameObject PlatformTalisman;
    Grid currentGrid;
    
    [Header("Energy")]
    [SerializeField] int energy = 100;
    [SerializeField] int attackTalismanCost = 10;
    [SerializeField] int platformTalismanCost = 5;

    void FixedUpdate() {
        Actions();    
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Grid") {
            currentGrid = col.gameObject.GetComponent<Grid>();   
        }
    }

    //TODO: instantiate looking in same direction as player
    private void Actions() {
        if (Input.GetKeyDown(KeyCode.F)) {
            if (energy >= attackTalismanCost) {
                GameObject currentTalisman = Instantiate(AttackTalisman, transform.position, transform.rotation);
                currentGrid.SetTalisman(currentTalisman);
                energy -= attackTalismanCost;
            }
        }
    }

    public void CreatePlatform() {
        if (energy >= platformTalismanCost){
            Vector3 transPos = new Vector3(transform.position.x, (transform.position.y - 1), transform.position.z);
            GameObject currentTalisman = Instantiate(PlatformTalisman, transPos, transform.rotation);
            energy -= platformTalismanCost;
        }
        
    }


}
