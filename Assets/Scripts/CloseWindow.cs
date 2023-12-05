using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    public static event System.Action WindowClosed;

    public void ShutDown()
    {
        gameObject.SetActive(false);
    }

    public void DestroyWindow()
    {
        WindowClosed?.Invoke();
        Destroy(gameObject);
    }
}
