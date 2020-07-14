using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
    [SerializeField] _SriptableLevel[] Stages;
    string currentStageKey = "CurrentStage";


    [SerializeField] GameObject[] AllStageObject;

    [SerializeField] GameObject[] Stage000;
    [SerializeField] GameObject[] Stage001;
    [SerializeField] GameObject[] Stage002;
    [SerializeField] GameObject[] Stage003;
    [SerializeField] GameObject[] Stage004;
    
    void Awake() {
        if (!PlayerPrefs.HasKey(currentStageKey)) {
            PlayerPrefs.SetInt(currentStageKey, 0);
        }   
    }

    void Start() {
        SetBuildStage();
    }

    public void SetBuildStage(){
        GameObject[] Stage;
        switch(PlayerPrefs.GetInt(currentStageKey)){
            case 1:
                Stage = Stage001;
                break;
            case 2:
                Stage = Stage002;
                break;
            case 3:
                Stage = Stage003;
                break;
            case 4:
                Stage = Stage004;
                break;
            default:
                Stage = Stage000;
                break;
        }
        BuildStage(Stage);
    }

    private void BuildStage(GameObject[] Stage) {
        foreach (GameObject obj in Stage)
        {
            obj.SetActive(true);
        }
    }

    public _SriptableLevel GetStage() {
        if (PlayerPrefs.GetInt(currentStageKey) > Stages.Length) {
            PlayerPrefs.SetInt(currentStageKey, 0);
        }
        return Stages[PlayerPrefs.GetInt(currentStageKey)];
        
    }

    public void IncrementStage(){
        int nextStage = PlayerPrefs.GetInt(currentStageKey) + 1;
        PlayerPrefs.SetInt(currentStageKey, nextStage);
    }
}