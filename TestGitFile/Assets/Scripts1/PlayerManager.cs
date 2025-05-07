using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;



    public GameObject pauseMenuScreen;
    // public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // playerHPText.text = "+" + playerHP;

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("TestMainMenu");
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("V1.2Portal");
    }
    /*public void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0)
        {
            isGameOver = true;
        }
    }*/
}
