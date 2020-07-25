using UnityEngine;

public class EnergyTalisman : MonoBehaviour {
    
    [SerializeField] Talisman Talisman;
    [SerializeField] int energyGain = 2;

    [Header("String Commands")]
    string increasedEnergy = "IncreaseEnergy";

    void Start() {
        Talisman = FindObjectOfType<Talisman>();
        InvokeRepeating(increasedEnergy, 0f, 3f);
    }

    void IncreaseEnergy(){
        Talisman.SetEnergy(energyGain);
    }

}
