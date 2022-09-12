using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollector : MonoBehaviour
{
    private GameObject[] asteroidHolders;
    private float distance = 4.5f;

    private float lastPosX;
    private float minPosY = -1.5f;
    private float maxPosY = 1.5f;

    void Awake()
    {
        asteroidHolders = GameObject.FindGameObjectsWithTag("AsteroidHolder");

        for (int i = 0; i < asteroidHolders.Length; i++)
        {
            Vector3 temp = asteroidHolders[i].transform.position;
            temp.y = Random.Range(minPosY, maxPosY);
            asteroidHolders[i].transform.position = temp;
        }

        lastPosX = asteroidHolders[0].transform.position.x;
        for (int i = 1; i < asteroidHolders.Length; i++)
        {
            if(lastPosX < asteroidHolders[i].transform.position.x)
            {
                lastPosX = asteroidHolders[i].transform.position.x;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "AsteroidHolder")
        {
            Vector3 temp = collision.transform.position;
            temp.x = lastPosX + distance;
            temp.y = Random.Range(minPosY, maxPosY);
            collision.transform.position = temp;

            lastPosX = temp.x;
        }
    }

}
