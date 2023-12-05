using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject paintWindow;
    public Button paintButton;
    public PaintPlayer player;

    // Update is called once per frame
    void Update()
    {
        if(player.damageCount <= 0)
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
        paintButton.interactable = true;
    }
}
