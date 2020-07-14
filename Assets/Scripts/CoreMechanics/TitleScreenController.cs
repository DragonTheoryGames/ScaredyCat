using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)){
            PlayerPrefs.SetInt("CurrentStage", 0);
            SceneManager.LoadScene(1);
        }
    }
}
