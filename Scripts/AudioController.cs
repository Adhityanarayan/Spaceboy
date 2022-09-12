using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;
    private AudioSource audioSource;

    void Awake()
    {
        //no need for singleton
        //MakeSingleton();
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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    void FixedUpdate()
    {
        if (!PlayerScript.instance.isAlive)
        {
            audioSource.Stop();
        }
    }
}
