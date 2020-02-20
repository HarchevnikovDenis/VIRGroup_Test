using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles = new List<GameObject>();
    private float timer;
    private GameObject nextObstacle;
    private float neededTime;

    private void Start()
    {
        GetRandomObstacle();
        Spawn();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        GetRandomObstacle();

        if(timer > neededTime)
        {
            Spawn();
            timer = 0.0f;
        }
    }

    private void Spawn()
    {
        GameObject obstacle = Instantiate(nextObstacle, transform.position, Quaternion.identity);
        if (obstacle.CompareTag("Lava"))
            neededTime = 6.0f;
        else
            neededTime = 3.5f;

        nextObstacle = null;
    }

    private void GetRandomObstacle()
    {
        if (nextObstacle == null)
            nextObstacle = obstacles[Random.Range(0, obstacles.Count)];
    }
}
