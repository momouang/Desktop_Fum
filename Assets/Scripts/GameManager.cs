using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void FailedGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
