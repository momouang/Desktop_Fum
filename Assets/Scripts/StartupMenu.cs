using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartupMenu : MonoBehaviour
{
    public Animator anim;
    public GameObject text;
    public GameObject loadingBar;
    public float endLoadingTime = 0;

    public bool isCounting = false;
    public bool isLoading = false;
    public bool loadingEnds = false;

    private void Start()
    {
        text.SetActive(false);
        loadingBar.SetActive(false);
        StartCoroutine(StartLoading());
    }

    private void Update()
    {
        if(isCounting)
        {
            endLoadingTime += Time.deltaTime;
        }
        if (endLoadingTime >= 5)
        {
            StopCoroutine(StartLoading());
            isLoading = false;
            text.SetActive(true);
            endLoadingTime = 5;
            loadingBar.SetActive(false);
            loadingEnds = true;
        }

        if(loadingEnds)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    IEnumerator StartLoading()
    {
        yield return new WaitForSeconds(3);
        loadingBar.SetActive(true);
        isCounting = true;

        while (isLoading)
        {
            yield return new WaitForSeconds(1);
            anim.Play("LoadingFill");           
        }
    }
}
