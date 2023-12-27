using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{

    public float closeCount;
    public bool isClosed = false;

    public void ShutDown()
    {
        gameObject.SetActive(false);
        isClosed = true;
    }

    virtual public void DestroyWindow()
    {
        Destroy(gameObject);
    }

}
