using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{

    public float closeCount;

    public void ShutDown()
    {
        gameObject.SetActive(false);
    }

    virtual public void DestroyWindow()
    {
        Destroy(gameObject);
    }
}
