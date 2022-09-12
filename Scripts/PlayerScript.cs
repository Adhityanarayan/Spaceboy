using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;

    private float forwardSpeed = 3f;
    private float bounceSpeed = 4f;

    private bool didFly;
    public bool isAlive;

    private Button FlyButton;
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClick, pointClip, diedClip;

    public int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isAlive = true;
        score = 0;
        //FlyButton = GameObject.FindGameObjectWithTag("FlyButton").GetComponent<Button>();
        //FlyButton.onClick.AddListener(() => FlyAstronaut());
        SetCameraX();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            didFly = true;
        }
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;
            //audioSource.PlayOneShot(backgroundClip);

            if (didFly)
            {
                didFly = false;
                rb.velocity = new Vector2(0, bounceSpeed);
                audioSource.PlayOneShot(flyClick);
                animator.SetTrigger("Fly");

                transform.rotation = Quaternion.Euler(0, 0, 16);
            }

            if (rb.velocity.y <= 0)
            {
                float angle = 0;
                angle = Mathf.Lerp(15, -16, -rb.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    void SetCameraX()
    {
        CameraScript.offsetX = (Camera.main.transform.position.x) + 4f;
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }

    public void FlyAstronaut()
    {
        didFly = true;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        //if (target.gameObject.tag == "Ground" || target.gameObject.tag == "Asteroid")
        if (target.gameObject.tag == "Asteroid")
        {
            if (isAlive)
            {
                isAlive = false;
                //animator.SetTrigger("Bird Died");
                audioSource.PlayOneShot(diedClip);
                GameplayController.instance.PlayerDiedShowScore(score);
                //AdsController.instance.ShowInterstitial();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "AsteroidHolder")
        {
            score++;
            GameplayController.instance.SetScore(score);
            audioSource.PlayOneShot(pointClip);
        }
        if (target.gameObject.tag == "Ground")
        {
            if (isAlive)
            {
                isAlive = false;
                //animator.SetTrigger("Bird Died");
                audioSource.PlayOneShot(diedClip);
                GameplayController.instance.PlayerDiedShowScore(score);
                //AdsController.instance.ShowInterstitial();
            }
        }
    }
}
