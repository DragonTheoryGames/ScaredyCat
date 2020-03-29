using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {
    
    [SerializeField] GameObject character;
    Transform charTForm;
    Transform tForm;
    Slider slider;

    void Start() {
        charTForm = character.GetComponent<Transform>();
        tForm = GetComponent<Transform>();
        slider = GetComponent<Slider>();
    }
 
    // Update is called once per frame
    void FixedUpdate() {
        SetPosition();
    }

    void SetPosition(){
        float characterPosX = charTForm.position.x;
        float characterPosY = charTForm.position.y + 2;
        GetComponent<Transform>().position = new Vector2(characterPosX, characterPosY);
    }

    public void UpdateValue(int value) {
        slider.value = value;
    }
}
