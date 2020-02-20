using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private Vector3 movement;

    private void Start()
    {
        Destroy(gameObject, 15.0f);
        movement = -Vector3.right;
    }

    private void Update()
    {
        transform.Translate(movement * Time.deltaTime * ScoreManager.speed);
    }
}
