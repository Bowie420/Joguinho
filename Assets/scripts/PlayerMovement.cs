using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    
    private Vector2 transformDirection; 
    public string sceneLoader;
    public float changeTime = 30.0f;
    public float gameoverTime = 60.0f;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isDead = false;
   
    private enum MovementState { idle, walking }
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        changeTime -= Time.deltaTime;

        if (changeTime <= 0.0f)
        {
            changeScene();
        }
        if (gameoverTime <= 0.0f)
        {
            gameoverScene();
        }

        if (!isDead)
        {
            MovePlayer();
        }
    }



     void MovePlayer()
    {
        float transformX = Input.GetAxis("Horizontal");
        float transformY = Input.GetAxis("Vertical");
        transformDirection = new Vector2(transformX, transformY);

        // Set the "isWlking" parameter based on player's movement
        bool isWalking = Mathf.Abs(transformX) > 0.1f || Mathf.Abs(transformY) > 0.1f;
        anim.SetBool("isWalking", isWalking);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("vermelhinha"))
        {
            Death();
        }
        if (collision.gameObject.CompareTag("mami"))
        {
            Death();
        }
    }


    void Death()
    {

        isDead = true;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        
    }
    void FixedUpdate() // good for physics calculations
    {
        rb.velocity = new Vector2(transformDirection.x * Speed, transformDirection.y * Speed);
    }
   
    void changeScene()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
         player.transform.position = playerPosition;

    }

    void gameoverScene()
    {
        SceneManager.LoadScene("gameover");
    }
}
