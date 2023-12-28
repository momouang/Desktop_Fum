using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator anim;
    public float transitionTime = 1f;

    public void FailedGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainScene()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadStartupScene()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
