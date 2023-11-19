using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Whey : MonoBehaviour
{
    [SerializeField] float Duration = 10f;
    [SerializeField] float scalingFactor = 0.5f;
    [SerializeField] float respawnTime = 10f;

    private bool isActivated = false;
    private SpriteRenderer sr;
    private BoxCollider2D collider;

    private Dictionary<GameObject, Vector3> originalScales = new Dictionary<GameObject, Vector3>();

    private void Start()
    {
        // Cache components for efficiency
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

        // Start the respawn delay
        StartCoroutine(SpawnTime());
    }


    IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }
   
    void Respawn()
    {
        // Set a random position for the power-up
        SetRandomPosition();

        // Activate the SpriteRenderer and BoxCollider2D
        State(true);

        // Start the respawn delay again
        StartCoroutine(SpawnTime());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for player collision and ensure the power-up is not already activated
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            Activate();
        }
    }

    void Activate()
    {
        // Scale down objects with the specified tags
        ScaleObjects("vermelhinha");
        ScaleObjects("mami");

        // Deactivate the SpriteRenderer and BoxCollider2D
        State(false);

        // Reset the respawn delay
        StopAllCoroutines();
        StartCoroutine(Scaleup());
    }

    IEnumerator Scaleup()
    {
        yield return new WaitForSeconds(Duration);

        // Return objects to their normal size after the power-up duration
        ScaleObjectsUp("mami");
        ScaleObjectsUp("vermelhinha");

        // Reactivate the SpriteRenderer and BoxCollider2D
        State(true);

        // Reset the activation flag
        isActivated = false;

        // Respawn the power-up after a delay
        StartCoroutine(SpawnTime());
    }
    void ScaleObjects(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {
            // Store the original scale before scaling down
            originalScales[obj] = obj.transform.localScale;

            // Scale down the object
            obj.transform.localScale *= scalingFactor;
        }
    }

    void ScaleObjectsUp(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {

            // Check if the object was previously scaled down
            if (originalScales.TryGetValue(obj, out Vector3 originalScale))
            {
                // Scale it back to its original size
                obj.transform.localScale = originalScale;
            }

        }
        // Clear the dictionary
        originalScales.Clear();
    }

   

    void State(bool state)
    {
        // Enable or disable the SpriteRenderer and BoxCollider2D
        sr.enabled = state;
        collider.enabled = state;
    }

    void SetRandomPosition()
    {
        // Set a random position for the power-up
        transform.position = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0f);
    }

    
}
