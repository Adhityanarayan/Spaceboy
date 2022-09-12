using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    

    public float moveSpeed = 2f;
    public float maxVelocity = 4f;
    public float moveScale = 1.2f;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //PlayerScale();
    }

    void PlayerScale()
    {
        if(transform.position.y > 0)
        {
            Vector3 temp = transform.localScale;
            temp.y = moveScale * (transform.position.y / 3);
            transform.localScale = temp;
        }
        else
        {
            Vector3 temp = transform.localScale;
            temp.y = -moveScale * (transform.position.y / 3);
            transform.localScale = temp;
        }
    }
}
