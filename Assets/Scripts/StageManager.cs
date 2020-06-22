using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] _SriptableLevel[] Stages;
    [SerializeField] static int CurrentStage = -1;
    [SerializeField] List<GameObject> Environment;

    void Awake() {
        Environment = Stages[0].Environment;
        BuildStage();
    }

    private void BuildStage() {
        foreach (GameObject obj in Environment){
            Instantiate(obj);
        } 
    }

    public _SriptableLevel GetStage() {
        if (CurrentStage > Stages.Length) {
            CurrentStage = 0;
        }
        CurrentStage = CurrentStage + 1;
        return Stages[CurrentStage];
        
    }
}
