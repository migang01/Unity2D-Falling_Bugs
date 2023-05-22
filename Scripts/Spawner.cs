using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject[] Bug;
    public float secondsBetweenSpawns = 1;
    float nextSpawnTime;

    Vector2 screenHalfSizeWorldUnits;

    private void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    private void Update()
    {
        if(Score.score >= 50)
        {
            secondsBetweenSpawns = .5f;
        }

        if(Time.time>nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + 1f);
            GameObject newBug = (GameObject)Instantiate(Bug[Random.Range(0, 3)], spawnPosition, Quaternion.identity);
            newBug.transform.localScale = Vector2.one;
        }
    }
}
