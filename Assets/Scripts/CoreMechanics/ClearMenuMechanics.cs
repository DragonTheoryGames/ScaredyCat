using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMenuMechanics : MonoBehaviour {
    
    [SerializeField] GameObject Player;
    [SerializeField] GameObject EnemySpawner;

    string currentStageKey = "CurrentStage";

    private void Start() {
        ClearMechanics();
    }

    private void ClearMechanics() {
        if (PlayerPrefs.GetInt(currentStageKey) == 0){
            Player.SetActive(false);
            EnemySpawner.SetActive(false);
        }
    }

}
