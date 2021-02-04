using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {
    
    [SerializeField] Image Slider;
    [SerializeField] float maxValue = 100;

    public void UpdateMaxValue(float newMaxValue){
        maxValue = newMaxValue;
    }

    public void UpdateValue(float value) {
        Slider.fillAmount = value/maxValue * 0.5f;
    }
}
