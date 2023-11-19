using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 currentDirection;
    [SerializeField] GameObject RedCircle;
    [SerializeField] GameObject bigMamiSpawn;
    private float RangeX = 2f;
    private float RangeY = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomDirection();
    }

    void Update()
    {
        // Move the sprite in its current direction
        rb.velocity = currentDirection * speed;
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
            // Reflect off the wall
            ReflectOffWall(collision.GetContact(0).normal);
        }
        if (collision.gameObject.CompareTag("mami"))
        {
            // Reflect off the wall
            ReflectOffWall(collision.GetContact(0).normal);
        }
        // Check if colliding with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reflect off the player (you can implement this logic based on your game design)
            ReflectOffPlayer();
            SpawnredCircle();
        }
    }

    private void SpawnredCircle()
    {
        int randomSpawn = Random.Range(0, 2);

        float randomX = Random.Range(-RangeX, RangeX);
        float randomY = Random.Range(-RangeY, RangeY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);
        
        if (randomSpawn == 0)
        {
            Instantiate(RedCircle, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(bigMamiSpawn, spawnPosition, Quaternion.identity);
        }
    }

    
    void SetRandomDirection()
    {
        // Set a new random direction for the sprite
        currentDirection = Random.insideUnitCircle.normalized;
    }

    void ReflectOffWall(Vector2 wallNormal)
    {
        
        currentDirection = Vector2.Reflect(currentDirection, wallNormal);
    }

    void ReflectOffPlayer()
    {
        GameManager.Instance.IncreasePoints();
        Vector2 newPosition = new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f));
        transform.position = newPosition;
    }
}
