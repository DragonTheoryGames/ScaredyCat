using UnityEngine;

public class EnergyTalisman : MonoBehaviour {
    
    [SerializeField] Talisman Talisman;

    void Start() {
        Talisman = FindObjectOfType<Talisman>();
    }

    void IncreaseEnergy(int energyIncrease){
        Talisman.SetEnergy(energyIncrease);
    }

}
