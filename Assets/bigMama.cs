using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigMama : MonoBehaviour
{
    private Vector2 currentDirection;
    private SpriteRenderer sr;
    private Vector2 direction;
    private GameObject player;
    [SerializeField] float speed = 8f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Move the sprite in its current direction
        rb.velocity = currentDirection * speed;
        // Update the sprite based on the direction
        if (direction.x > 0)
        {
            // Moving to the right, flip the sprite to face right
            sr.flipX = true;
        }
        else if (direction.x < 0)
        {
            // Moving to the left, flip the sprite to face left
            sr.flipX = false;
        }

        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 mamiPosition = player.transform.position;
            direction = (mamiPosition - (Vector2)transform.position).normalized;
        }
        else if (collision.gameObject.CompareTag("Verdinha"))
        {
            Vector2 mamiPosition = player.transform.position;
            direction = (mamiPosition - (Vector2)transform.position).normalized;
        }
        else if (collision.gameObject.CompareTag("vermelhinha"))
        {
            Vector2 mamiPosition = player.transform.position;
            direction = (mamiPosition - (Vector2)transform.position).normalized;
        }
        else if (collision.gameObject.CompareTag("mami"))
        {
            Vector2 mamiPosition = player.transform.position;
            direction = (mamiPosition - (Vector2)transform.position).normalized;
        }
    }
}

