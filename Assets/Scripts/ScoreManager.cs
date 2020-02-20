using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(Animator))]
public class ScoreManager : MonoBehaviour
{
    private Text text;
    private Animator animator;
    private float score;
    private float extraCountScore; //Score при котором возрастает скорость препятствий (каждые 100)

    [HideInInspector] public static float speed;

    private void Start()
    {
        speed = 3.0f;
        text = GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        extraCountScore += 2.5f * Time.deltaTime;
        score += 2.5f * Time.deltaTime;
        int scoreInt = (int)score;
        text.text = scoreInt.ToString();

        if(extraCountScore > 100.0f)
        {
            MultiplyScore();
        }
    }

    private void MultiplyScore()
    {
        extraCountScore = 0.0f;
        speed *= 1.1f;
        animator.SetTrigger("MultiplyScore");
    }
}
