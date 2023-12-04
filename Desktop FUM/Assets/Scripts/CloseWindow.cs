using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    public void ShutDown()
    {
        gameObject.SetActive(false);
    }

    public void DestroyWindow()
    {
        Destroy(gameObject);
    }
}
