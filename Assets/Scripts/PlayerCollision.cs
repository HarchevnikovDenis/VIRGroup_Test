using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator;
    [SerializeField] private GameObject losePanel;
    private bool isGameOver;

    [SerializeField] private float range;

    public void Lose()
    {
        cameraAnimator.SetTrigger("Shake");
        Time.timeScale = 0.0f;
        losePanel.SetActive(true);
    }

    private void Update()
    {
        if (isGameOver)
            return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject.GetComponent<MovingObstacle>())
            {
                Lose();
                isGameOver = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
