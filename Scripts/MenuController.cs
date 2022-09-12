using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    //[SerializeField]
    //private GameObject[] astronauts;

    void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        //astronauts[GameController.instance.GetSelectedAstronaut()].SetActive(true);
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayGame()
    {
        SceneFader.instance.FadeIn("GamePlay");
    }
}
