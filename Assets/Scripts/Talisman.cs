using System;
using UnityEngine;

public class Talisman : MonoBehaviour {
    
    [Header("Talismans")]
    [SerializeField] GameObject PlatformTalisman;
    [SerializeField] GameObject[] Talismans;
    Grid currentGrid;
    int nameCounter = 0;
    
    [Header("Energy")]
    [SerializeField] int energy;
    [SerializeField] int[] TalismanCost;
    int platformTalismanCost = 5;
    [SerializeField] int energyGain = 1;
    float lastTime;
    [SerializeField] float energyTime;
    [SerializeField] SliderController energyBar;

    void Awake() {
        lastTime = Time.time;
    }

    void FixedUpdate() {
        StaticEnergyIncrease();
        UpdateEnergy();
    }
    

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Grid") {
            currentGrid = col.gameObject.GetComponent<Grid>();
        }
    }

    public void SetTalisman(int newTalisman) {
        GameObject talisman = Talismans[newTalisman];
        int talismanCost = TalismanCost[newTalisman];

        if (energy >= talismanCost) {
            energy -= talismanCost;
            GameObject currentTalisman = Instantiate(talisman, transform.position, transform.rotation);
            currentGrid.SetTalisman(currentTalisman);
            currentTalisman.name = "Talisman " + nameCounter.ToString();
            nameCounter++;
            if(newTalisman == 2){
                currentTalisman.GetComponent<AutumnTalisman>().SetGrid(currentGrid);
            }
        }
            
    }

    public void CreatePlatform(float dirX) {
        if (energy >= platformTalismanCost){
            Vector3 transPos = new Vector3(transform.position.x + dirX, (transform.position.y - 2f), transform.position.z);
            GameObject currentTalisman = Instantiate(PlatformTalisman, transPos, transform.rotation);
            currentTalisman.GetComponent<PlatformController>().player = this.GetComponent<Rigidbody2D>(); 
            energy -= platformTalismanCost;
        } 
    }

    void StaticEnergyIncrease(){
        if (Time.time >= lastTime + energyTime) {
            lastTime = Time.time;
            SetEnergy(energyGain);
        }
    }

    public void SetEnergy(int energyIncrease){
        energy += energyIncrease;
        if (energy >= 100) {
            energy = 100;
        }
    }

    public void UpdateEnergy() {
        energyBar.UpdateValue(energy);
    }
}
