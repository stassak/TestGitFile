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
    public TextMeshProUGUI scoreText;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        score = 0;
        scoreText = "Score: " + score;
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
        //adding to do freeze of the logic player and sounds
        if (isGameOver) return;
        gameOverText.gameObject.SetActive(true);
        //xFindObjectOfType<Player>().enabled = false; // Player is the class

        Time.timeScale = 0f; // optional freeze every thing
        AudioSource[] enemyAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in enemyAudioSources)
        {
            if (audio.gameObject.CompareTag("Enemy"))
            {
                audio.Stop();
            }
        }

        Time.timeScale = 0f;
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
