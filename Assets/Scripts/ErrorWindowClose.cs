using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorWindowClose : CloseWindow
{
    public static event System.Action ErrorWindowCloseEvent;

    public override void DestroyWindow()
    {
        ErrorWindowCloseEvent?.Invoke();
        Destroy(gameObject);
    }
}
