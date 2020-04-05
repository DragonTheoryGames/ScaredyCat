using UnityEngine;
using UnityEngine.UI;

public class HumanController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float sanity = 100;

    [SerializeField] Text gameOver;

    public void UpdateSanity(int damage){
        sanity = sanity - damage;
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
