using System;
using UnityEngine;

public class Talisman : MonoBehaviour {
    
    [Header("Talismans")]
    [SerializeField] GameObject AttackTalisman;
    [SerializeField] GameObject PlatformTalisman;
    [SerializeField] GameObject EnergyTalisman;
    Grid currentGrid;
    
    [Header("Energy")]
    [SerializeField] int energy;
    int attackTalismanCost = 10;
    int energyTalismanCost = 15;
    int platformTalismanCost = 5;
    [SerializeField] int energyGain = 1;
    float lastTime;
    [SerializeField] float energyTime; 

    void Start() {
       lastTime = Time.time; 
    }

    void FixedUpdate() { 
        StaticEnergyIncrease();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Grid") {
            currentGrid = col.gameObject.GetComponent<Grid>();   
        }
    }

    //TODO: face the enemy its attacking
    void SetAttackTalisman() { //called by message from PlayerController
        if (energy >= attackTalismanCost) {
            GameObject currentTalisman = Instantiate(AttackTalisman, transform.position, transform.rotation);
            currentGrid.SetTalisman(currentTalisman);
            energy -= attackTalismanCost;
        }
    }

    void SetEnergyTalisman() { //called by message from PlayerController
        if (energy >= energyTalismanCost) {
            GameObject currentTalisman = Instantiate(EnergyTalisman, transform.position, transform.rotation);
            currentGrid.SetTalisman(currentTalisman);
            energy -= energyTalismanCost;
        }
    }

    void CreatePlatform() {
        if (energy >= platformTalismanCost){
            Vector3 transPos = new Vector3(transform.position.x, (transform.position.y - 1.2f), transform.position.z);
            GameObject currentTalisman = Instantiate(PlatformTalisman, transPos, transform.rotation);
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

    public int GetEnergy() { //called by SliderController
        return energy;
    }
}
