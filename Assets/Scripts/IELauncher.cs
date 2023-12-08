using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IELauncher : AppLauncher
{
    public bool isDownloaded = false;
    public GameObject downloadWindow, explorerWindow;

    public override void OpenWindow()
    {
        if (isDownloaded)
        {
            explorerWindow.SetActive(true);
        }
        else
        {
            downloadWindow.SetActive(true);
        }

    }
}
