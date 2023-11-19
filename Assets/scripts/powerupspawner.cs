using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupspawner : MonoBehaviour
{

    public float changeTime = 10.0f;
    public float RangeX = 2f;
    public float RangeY = 2f;
    [SerializeField] GameObject Whey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnWhey()
    {
        float randomX = Random.Range(-RangeX, RangeX);
        float randomY = Random.Range(-RangeY, RangeY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);
            Instantiate(Whey, spawnPosition, Quaternion.identity);
        
    }
    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;

        if (changeTime == 0.0f)
        {
            SpawnWhey();
        }
    }
}
