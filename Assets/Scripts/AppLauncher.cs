using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLauncher : MonoBehaviour
{
    public GameObject[] AppWindow;
    public bool isOpened;

    public virtual void OpenWindow()
    {
        isOpened = true;

        for (int i= 0; i < AppWindow.Length ;i++)
        {
            AppWindow[i].SetActive(true);
        }
    }


}
