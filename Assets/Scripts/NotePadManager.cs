using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePadManager : MonoBehaviour
{
    public AppLauncher NotePadApp;
    public CloseWindow closeWindow;
    public GameObject[] CrossNotes;
    public ParticleSystem[] CheeringParticle;

    public bool[] gameCompletes;
    public GameObject CongratsText;

    private void Start()
    {
        for (int j = 0; j < 4; j++)
        {
            CheeringParticle[j].Stop();
        }
        for (int i = 0; i < 6; i++)
        {
            CrossNotes[i].SetActive(false);
        }
    }

    private void OnEnable()
    {
        GameMonitor.GameComplete += OnGameComplete;
    }

    private void OnDisable()
    {
        GameMonitor.GameComplete -= OnGameComplete;
    }

    public void OnGameComplete(int state)
    {
        gameCompletes[state] = true;
        CrossNotes[state].SetActive(true);

        if(state == 4)
        {
            CrossNotes[5].SetActive(false);
        }

        foreach(bool n in gameCompletes)
        {
            if(n == false)
            {
                return;
            }            
        }
        CongratsText.SetActive(true);
        
    }

}
