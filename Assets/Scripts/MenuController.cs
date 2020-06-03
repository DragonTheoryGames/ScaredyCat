using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    [SerializeField] Button button;


    private void FixedUpdate() {
        MenuInput();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Button") {
            button = col.gameObject.GetComponent<Button>();
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject == button.gameObject) {
            button = null;
        }
    }

    private void MenuInput() {
        if (Input.GetKey(KeyCode.F)) {
            switch (button.name) {
                case "NewGameButton":
                    SceneManager.LoadScene(1);
                    break;
            }
        }
    }

}
