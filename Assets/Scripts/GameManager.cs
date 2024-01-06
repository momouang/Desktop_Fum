using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMonitor
{
    public static event System.Action<int> GameComplete;

    public static void GameCompleteTrigger(int stage)
    {
        GameComplete?.Invoke(stage);
    }
}

public class GameManager : MonoBehaviour
{
    public Animator anim;
    public float transitionTime = 1f;
    public bool isplayingMusic = false;

    public bool gameStarted = false;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(SceneManager.GetActiveScene().name == "Main")
        {
            isplayingMusic = true;
        }
    }

    private void Update()
    {
        if(isplayingMusic)
        {
            isplayingMusic = false;
            StartCoroutine(LoadBGMusic());
        }
    }

    public void FailedGame()
    {
        isplayingMusic = false;
        FindObjectOfType<AudioManager>().Stop("BG Music");
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

    IEnumerator LoadBGMusic()
    {
        yield return new WaitForSeconds(3f);
        FindObjectOfType<AudioManager>().Play("BG Music");
    }

}
