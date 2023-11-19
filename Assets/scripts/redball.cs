using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redball : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 currentDirection;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.insideUnitCircle.normalized;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        SetRandomDirection();
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
           sr.flipX = false;
        }
        else if (direction.x < 0)
        {
            // Moving to the left, flip the sprite to face left
            sr.flipX = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if colliding with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reflect off the wall
            ReflectOffWall(collision.GetContact(0).normal);
        }
        if (collision.gameObject.CompareTag("vermelhinha"))
        {
            ReflectOffWall(collision.GetContact(0).normal);
        }
        if (collision.gameObject.CompareTag("mami"))
        {
            // Reflect off the wall
            ReflectOffWall(collision.GetContact(0).normal);
        }
        if (collision.gameObject.CompareTag("Verdinha"))
        {
            ReflectOffWall(collision.GetContact(0).normal);
        }
        // Check if colliding with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reflect off the player (you can implement this logic based on your game design)
            ReflectOffPlayer();
            
        }
    }

    void SetRandomDirection()
    {
        // Set a new random direction for the sprite
        currentDirection = Random.insideUnitCircle.normalized;
    }

    void ReflectOffWall(Vector2 wallNormal)
    {
        // Reflect the current direction off the wall normal
        currentDirection = Vector2.Reflect(currentDirection, wallNormal);
    }

    void ReflectOffPlayer()
    {
        // Implement logic to reflect off the player if needed
        // For example, you might want to reverse the direction
        currentDirection = -currentDirection;
    }

}
