using UnityEngine;

public class LoadStage : MonoBehaviour {
    [SerializeField] StageManager _StageManager;

    void Start() {
        _StageManager.SetBuildStage();
    }
}
