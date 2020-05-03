using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    [SerializeField] GameObject button;


    private void FixedUpdate() {
        MenuInput();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Button") {
            button = col.gameObject;
        }
        Debug.Log(col.gameObject);
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject == button) {
            button = null;
        }
    }

    private void MenuInput() {
        if (Input.GetKey(KeyCode.F)) {
            
        }
    }

}
