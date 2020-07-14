using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour {

    [SerializeField] Text CurrentLevelText;
    string currentStageKey = "CurrentStage";

    void FixedUpdate() {
        CurrentLevelText.text = "Stage: " + PlayerPrefs.GetInt(currentStageKey).ToString();
    }

}
