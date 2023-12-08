using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintLauncher : AppLauncher
{
    public GameObject paintWindow;
    public GameObject drawMesh;
    public PaintManager paintManager;

    public override void OpenWindow()
    {
        paintWindow.SetActive(true);

        if(paintManager.endGame)
        {
            drawMesh.SetActive(true);
        }
    }

    public void ClosePaintWindow()
    {
        drawMesh.SetActive(false);
    }
}
