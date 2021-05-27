
using UnityEngine;

public class FadeInDTG : MonoBehaviour {
    
    [SerializeField] LevelLoader LevelLoader;

    public void CallSoundScene() {
        LevelLoader.NextScene();
    }
}
