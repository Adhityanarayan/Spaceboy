using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private const string HIGH_SCORE = "High Score";
    private const string SELECTED_ASTRONAUT = "Selected Astronaut";

    private void Awake()
    {
        MakeSingleton();
        IsTheGameStartedForTheFirstTime();
    }
    void Start()
    {
        
    }
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void IsTheGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsTheGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt(SELECTED_ASTRONAUT, 0);
            PlayerPrefs.SetInt("IsTheGameStartedForTheFirstTime", 0);
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
    public void SetSelectedAstronaut(int selectedAstronaut)
    {
        PlayerPrefs.SetInt(SELECTED_ASTRONAUT, selectedAstronaut);
    }

    public int GetSelectedAstronaut()
    {
        return PlayerPrefs.GetInt(SELECTED_ASTRONAUT);
    }
}
