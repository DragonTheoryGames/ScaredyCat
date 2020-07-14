using UnityEngine;

public class EnergyTalisman : MonoBehaviour {
    
    [SerializeField] Talisman Talisman;
    int energyGain = 2;

    void Start() {
        Talisman = FindObjectOfType<Talisman>();
        InvokeRepeating("IncreaseEnergy", 0f, 3f);
    }

    void IncreaseEnergy(){
        Talisman.SetEnergy(energyGain);
    }

}
