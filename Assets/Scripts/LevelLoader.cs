using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void RestartLevel()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(0.75f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
