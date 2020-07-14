using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {
    
    Slider Slider;

    void Start() {
        Slider = GetComponent<Slider>();
    }

    public void UpdateValue(float value) {
        Slider.value = value;
    }
}
