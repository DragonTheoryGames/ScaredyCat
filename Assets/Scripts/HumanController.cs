using UnityEngine;
using UnityEngine.UI;

public class HumanController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float sanity = 50;

    [SerializeField] Text gameOver;

    public void UpdateSanity(int damage) {
        sanity = sanity - damage;
        if (sanity > 100) { sanity = 100; }
        UpdateValue();
    }

    public void UpdateValue() {
        slider.value = sanity;
        if (sanity <= 0) {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }



}
