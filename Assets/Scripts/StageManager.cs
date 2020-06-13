using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] _SriptableLevel[] Stages;
    [SerializeField] static int CurrentStage = -1;

   

    public _SriptableLevel GetStage() {
        CurrentStage = CurrentStage + 1;
        if (CurrentStage > Stages.Length) {
            CurrentStage = 0;
        } 
        return Stages[CurrentStage];
        
    }
}
