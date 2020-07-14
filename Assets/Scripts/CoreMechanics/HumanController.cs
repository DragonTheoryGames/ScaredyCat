using UnityEngine;
using UnityEngine.UI;

public class HumanController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float sanity = 50;

    [SerializeField] GameManager GameManager;

    public void UpdateSanity(float damage) {
        sanity = sanity - damage;
        sanity = (sanity > 100) ? 100 : sanity;
        UpdateValue();
    }

    void UpdateValue() {
        slider.GetComponent<SliderController>().UpdateValue(sanity);
        if (sanity <= 0) {
            GameManager.GameOver();
        }
    }
}
