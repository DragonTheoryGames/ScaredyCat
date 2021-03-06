﻿using System;
using UnityEngine;

public class Talisman : MonoBehaviour {
    
    [Header("Talismans")]
    [SerializeField] GameObject PlatformTalisman;
    [SerializeField] GameObject[] Talismans;
    [SerializeField] Grid currentGrid;
    int nameCounter = 0;
    
    [Header("Energy")]
    [SerializeField] int energy;
    [SerializeField] int[] TalismanCost;
    int platformTalismanCost = 5;
    [SerializeField] int energyGain = 1;
    float lastTime;
    [SerializeField] float energyTime;
    [SerializeField] SliderController energyBar;

    [Header("String Commands")]
    string grid = "Grid";
    string talismanName = "Talisman ";

    void Awake() {
        lastTime = Time.time;
    }

    void FixedUpdate() {
        StaticEnergyIncrease();
        UpdateEnergy();
    }
    

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == grid) {
            currentGrid = col.gameObject.GetComponent<Grid>();
        }
    }

    public void SetTalisman(int newTalisman) {
        GameObject talisman = Talismans[newTalisman];
        int reducedTalismanCost = FindReducedTalismanCost(newTalisman);
        int talismanCost = TalismanCost[newTalisman];

        if (energy >= talismanCost) {
            energy -= talismanCost;
            GameObject currentTalisman = Instantiate(talisman, transform.position, transform.rotation);
            currentGrid.SetTalisman(currentTalisman);
            currentTalisman.name = talismanName + nameCounter.ToString();
            nameCounter++;
            if(newTalisman == 2){
                currentTalisman.GetComponent<AutumnTalisman>().SetGrid(currentGrid);
            }
            else if(newTalisman == 3){
                currentTalisman.GetComponent<WinterTalisman>().SetGrid(currentGrid);
            }
        }
            
    }

    private int FindReducedTalismanCost(int newTalisman) {
        int reducedCost = 0;
        if (newTalisman == 0) { reducedCost = PowersManager.springCost; }
        if (newTalisman == 1) { reducedCost = PowersManager.summerCost; }
        if (newTalisman == 2) { reducedCost = PowersManager.autumnCost; }
        if (newTalisman == 3) { reducedCost = PowersManager.winterCost; }
        return reducedCost;

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
