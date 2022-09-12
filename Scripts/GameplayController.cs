using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, endScore, bestScore, gameOverText;

    [SerializeField]
    private Button restartGameButton; 
    //instructionsButton;

    [SerializeField]
    private GameObject pausePanel;
    void Awake()
    {
        MakeInstance();
        Time.timeScale = 0f;
    }
    void Start()
    {
        Time.timeScale = 1f;
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PauseGame()
    {
        if(PlayerScript.instance != null)
        {
            if (PlayerScript.instance.isAlive)
            {
                pausePanel.SetActive(true);
                gameOverText.gameObject.SetActive(true);
                endScore.text = "" + PlayerScript.instance.score;
                bestScore.text = "" + GameController.instance.GetHighScore();
                Time.timeScale = 0f;
                restartGameButton.onClick.RemoveAllListeners();
                restartGameButton.onClick.AddListener(() => ResumeGame());
            }
        }
    }

    public void GoToMenuButton()
    {
        SceneFader.instance.FadeIn("MainMenu");
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        SceneFader.instance.FadeIn(SceneManager.GetActiveScene().name);
        //Debug.Log(SceneManager.GetActiveScene().name);
    }
    public void PlayGame()
    {
        //pausePanel.SetActive(true);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void PlayerDiedShowScore(int score)
    {
        pausePanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);

        endScore.text = "" + score;

        if (score > GameController.instance.GetHighScore())
        {
            GameController.instance.SetHighScore(score);
        }

        bestScore.text = "" + GameController.instance.GetHighScore();

        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => RestartGame());
    }
}
