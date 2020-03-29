using UnityEngine;

public class PlatformController : MonoBehaviour {
    
    [SerializeField]
    public Rigidbody2D player;
    private BoxCollider2D box;
    [SerializeField]
    bool playerJumping;

    void Start(){
        box = this.GetComponent<BoxCollider2D>(); 
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S)) {
            box.enabled = false;
            playerJumping = true;
        }
        else {
            box.enabled = true;
            playerJumping = false;
        }
    }
}
