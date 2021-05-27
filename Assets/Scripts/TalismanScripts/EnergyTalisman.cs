using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergyTalisman : MonoBehaviour {
    
    [SerializeField] Talisman Talisman;
    [SerializeField] int energyGain = 2;

    [Header("String Commands")]
    string increasedEnergy = "IncreaseEnergy";

    void Start() {
        Talisman = FindObjectOfType<Talisman>();
        StartCoroutine(IncreaseEnergy());
    }

    IEnumerator IncreaseEnergy() {
        Talisman.SetEnergy(energyGain + PowersManager.springPower);
        yield return new WaitForSeconds(3f - (PowersManager.springSpeed/10));
        StartCoroutine(IncreaseEnergy());
    }

}
