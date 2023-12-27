using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintManager : MonoBehaviour
{
    public GameObject paintWindow;
    public Button paintButton;
    public PaintEnemy enemy;
    public bool endGame = false;

    public NotePadManager notepadManager;

    // Update is called once per frame
    void Update()
    {
        if(enemy.damageCount <= 0)
        {
            endPaintGame();
        }
    }

    public void openPaintWindow()
    {
        //paintWindow.SetActive(true);
        paintButton.interactable = false;
    }


    void endPaintGame()
    {
        endGame = true;
        paintButton.interactable = true;
        notepadManager.gameCompletes[0] = true;
    }

}
