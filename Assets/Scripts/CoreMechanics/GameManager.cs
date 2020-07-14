using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    [SerializeField] Text gameOver;

    public void GameOver() {
        gameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
