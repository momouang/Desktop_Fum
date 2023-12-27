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

    private void Start()
    {
        for (int j = 0; j < 4; j++)
        {
            CheeringParticle[j].Stop();
        }
        for (int i = 0; i < 5; i++)
        {
            CrossNotes[i].SetActive(false);
        }
    }

    private void Update()
    {

        if (gameCompletes[0])
        {
            for (int j = 0; j < 4; j++)
            {
                CheeringParticle[j].Play();
            }
            if (NotePadApp.isOpened)
            {
                CrossNotes[0].SetActive(true);
                closeWindow.isClosed = false;
            }

        }

        if (gameCompletes[1])
        {
            for (int j = 0; j < 4; j++)
            {
                CheeringParticle[j].Play();
            }
            if (NotePadApp.isOpened)
            {
                CrossNotes[1].SetActive(true);
                closeWindow.isClosed = false;
            }

        }

        if (gameCompletes[2])
        {
            for (int j = 0; j < 4; j++)
            {
                CheeringParticle[j].Play();
            }
            if (NotePadApp.isOpened)
            {
                CrossNotes[2].SetActive(true);
                closeWindow.isClosed = false;
            }

        }

        if (gameCompletes[3])
        {
            for (int j = 0; j < 4; j++)
            {
                CheeringParticle[j].Play();
            }
            if (NotePadApp.isOpened)
            {
                CrossNotes[3].SetActive(true);
                closeWindow.isClosed = false;
            }

        }

        if (gameCompletes[4])
        {
            for (int j = 0; j < 4; j++)
            {
                CheeringParticle[j].Play();
            }
            if (NotePadApp.isOpened)
            {
                CrossNotes[4].SetActive(true);
                closeWindow.isClosed = false;
            }

        }



        if (closeWindow.isClosed)
    {
        NotePadApp.isOpened = false;

        for(int i= 0; i<5; i++)
        {
            CrossNotes[i].SetActive(false);
        }
    }

    }


}
